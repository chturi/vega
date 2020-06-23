using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.Controllers.Resources;
using vega.Core.Models;
using vega.Core;

namespace vega.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public VehiclesController(IMapper mapper, IVehicleRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;       
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // var model = await context.Models.FindAsync(vehicleResource.ModelId);
            // if (model == null)
            // {
            //     ModelState.AddModelError("ModelId", "Invalid modelId");
            //     return BadRequest(ModelState);
            // }

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            repository.Add(vehicle);
            await unitOfWork.CompleteAsync();

            vehicle = await repository.GetVehicle(vehicle.Id);
            // vehicle = await context.Vehicles
            // .Include(v => v.Features)
            //     .ThenInclude(vf => vf.Feature)
            // .Include(v => v.Model)
            //     .ThenInclude(m => m.Make)
            // .SingleOrDefaultAsync(v => v.Id == vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);


        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            //this method checks that all the database Conditions are corret, if not it returns a pretty error
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
                return NotFound();


            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;


            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await repository.GetVehicle(id, includeRelated: false);


            if (vehicle == null)
                return NotFound();

            repository.Remove(vehicle);
            await unitOfWork.CompleteAsync();

            return Ok(id);


        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await repository.GetVehicle(id);


            if (vehicle == null)
                return NotFound();

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);

        }

        [HttpGet]
        public async Task<IEnumerable<VehicleResource>> GetVehicles(VehicleQueryResource filterResource)
        {
            var filter = mapper.Map<VehicleQueryResource, VehicleQuery>(filterResource);
            var vehicles = await repository.GetVehicles(filter);

            //
            return mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleResource>>(vehicles);

        }


    }
}
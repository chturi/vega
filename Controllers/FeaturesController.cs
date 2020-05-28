using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.Controllers.Resources;
using vega.Persistence;
using Microsoft.EntityFrameworkCore;
using vega.Models;

namespace vega.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;

        public FeaturesController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;


        }

        [HttpGet("api/features")]
        public async Task<IEnumerable<FeatureResource>> GetFeatures ()
        {

           var features = await context.Features.Include(m => m.Models).ToListAsync();

            return mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }



    }
}
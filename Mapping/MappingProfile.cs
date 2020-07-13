using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using vega.Controllers.Resources;
using vega.Core.Models;

namespace vega.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile() {

            //Domain to API Resource
            CreateMap(typeof(QueryResult<>),typeof(QueryResultResource<>));
            CreateMap<Make, MakeResource>();
            CreateMap<Make, KeyValuePairResource>();
            CreateMap<Model, KeyValuePairResource>();
            CreateMap<Feature, KeyValuePairResource>();
            

            CreateMap<Vehicle, SaveVehicleResource>()
            .ForMember(vr => vr.Contact , opt => opt.MapFrom(v => new ContactResource {Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone} ))
            .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));

            CreateMap<Vehicle, VehicleResource>()
            .ForMember(vr => vr.Make , opt => opt.MapFrom(v => v.Model.Make))
            .ForMember(vr => vr.Contact , opt => opt.MapFrom(v => new ContactResource {Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone} ))
            .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => new KeyValuePairResource {Id = vf.Feature.Id, Name= vf.Feature.Name})));
             
            
           
            //API resource to Domain
            CreateMap<VehicleQueryResource, VehicleQuery>();
            CreateMap<SaveVehicleResource, Vehicle>()
            .ForMember(v => v.Id, opt => opt.Ignore())
            .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
            .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
            .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
            .ForMember(v => v.Features, opt => opt.Ignore())
            .AfterMap((vr , v) => {
               
                //Remove unselected Features
                
                // var removedFeatures = new List<VehicleFeature>();
                // foreach (var f in v.Features)  
                //     if(vr.Features.Contains(f.FeatureId)) 
                //         removedFeatures.Add(f);

                var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId)).ToList();
                foreach (var f in removedFeatures)
                    v.Features.Remove(f);


                //Add new Features

                var addedFeatures = vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id)).Select(id => new VehicleFeature {FeatureId = id}).ToList();
                    foreach (var f in addedFeatures)
                        v.Features.Add(f);

                // foreach (var id in vr.Features)
                //     if(!v.Features.Any(f => f.FeatureId == id))
                //         v.Features.Add(new VehicleFeature {FeatureId = id});
                    
                 });


            
            
        
        
        }
        
    }
}
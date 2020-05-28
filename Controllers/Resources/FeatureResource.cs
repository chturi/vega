using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.Controllers.Resources
{
    public class FeatureResource
    {
        
        public int Id { get; set; }

        
        public string Name { get; set; }


        public ICollection<ModelResource> Models {get; set;}

        public FeatureResource(){

            Models = new Collection<ModelResource>();
            
        }

    }
}
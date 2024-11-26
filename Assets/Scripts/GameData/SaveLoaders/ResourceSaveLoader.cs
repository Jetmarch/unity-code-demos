using System.Collections.Generic;
using GameEngine;
// ReSharper disable ClassNeverInstantiated.Global

namespace HomeworkSaveLoad.SaveSystem.SaveLoaders
{
    public sealed class ResourceData
    {
        public string ID;
        public int Amount;
    }
    
    public sealed class ResourceSaveLoader : SaveLoader<IEnumerable<ResourceData>, ResourceService>
    {
        protected override void SetupData(ResourceService service, IEnumerable<ResourceData> data)
        {
            var resources = service.GetResources();

            foreach (var resource in resources)
            {
                foreach (var resourceData in data)
                {
                    if (resource.ID == resourceData.ID)
                    {
                        SetupResource(resource, resourceData);
                    }
                }
            }
        }

        private void SetupResource(Resource resource, ResourceData data)
        {
            resource.Amount = data.Amount;
        }

        protected override IEnumerable<ResourceData> ConvertToData(ResourceService service)
        {
            var resources = service.GetResources();
            var resourceData = new List<ResourceData>();

            foreach (var resource in resources)
            {
                var resData = new ResourceData
                {
                    ID = resource.ID,
                    Amount = resource.Amount
                };
                
                resourceData.Add(resData);
            }
            
            return resourceData;
        }
    }
}
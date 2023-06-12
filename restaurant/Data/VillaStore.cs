using System;
using restaurant.Models.Dto;
namespace restaurant.Data
{
    public class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto>
            {
                new VillaDto{id=0,name="Pool View"},
                new VillaDto{id=1,name="Beach View"},
            };
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidHelper.Models
{
    public class RegionDetailDTO
    {
        public string Iso { get; set; }
        public string Name { get; set; }
        public decimal Confirmed { get; set; }
        public decimal Deaths { get; set; }

        public static RegionDetailDTO FromModelToDTOByRegion(RegionDetail detail)
        {
            return detail != null ? new RegionDetailDTO
            {
               Iso = detail.Region.Iso,
               Name = detail.Region.Name,
               Confirmed = detail.Confirmed,
               Deaths = detail.Deaths
            } : null;
        }

        public static IEnumerable<RegionDetailDTO> FromModelToDTOByRegion(IEnumerable<RegionDetail> details)
        {
            if (details == null)
            {
                return new List<RegionDetailDTO>();
            }
            List<RegionDetailDTO> detailsData = new List<RegionDetailDTO>();

            foreach (var item in details)
            {
                detailsData.Add(FromModelToDTOByRegion(item));
            }

            return detailsData;
        }

        public static RegionDetailDTO FromModelToDTOByProvince(RegionDetail detail)
        {
            return detail != null ? new RegionDetailDTO
            {
                Iso = detail.Region.Iso,
                Name = detail.Region.Province,
                Confirmed = detail.Confirmed,
                Deaths = detail.Deaths
            } : null;
        }

        public static IEnumerable<RegionDetailDTO> FromModelToDTOByProvince(IEnumerable<RegionDetail> details)
        {
            if (details == null)
            {
                return new List<RegionDetailDTO>();
            }
            List<RegionDetailDTO> detailsData = new List<RegionDetailDTO>();

            foreach (var item in details)
            {
                detailsData.Add(FromModelToDTOByProvince(item));
            }

            return detailsData;
        }

    }
}

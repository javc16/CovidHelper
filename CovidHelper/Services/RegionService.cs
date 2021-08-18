using CovidHelper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CovidHelper.Services
{
    public class RegionService
    {
        public async Task<RegionData> GetAllRegions()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://covid-19-statistics.p.rapidapi.com/regions"),
                Headers =
                {
                    { "x-rapidapi-key", "f0185dd5camsh97364112a79dff9p1eed3djsn952cd7344b3d" },
                    { "x-rapidapi-host", "covid-19-statistics.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                var result = JsonConvert.DeserializeObject<RegionData>(body);
                return result;
            }
        }

        public async Task<RegionDetail> GetAllInformationByRegion(string regionName,string iso)
        {
            RegionDetailData result = await GetByRegion(regionName, iso);
            if (result.Data.Any())
            {
                var resultByCountry = result.Data.GroupBy(x => x.Region.Name)
                .Select(region => new RegionDetail
                {
                    Deaths = region.Sum(re => re.Deaths),
                    Confirmed = region.Sum(re => re.Confirmed),
                    Region = region.First().Region,
                }).ToList();

                return resultByCountry.FirstOrDefault();
            }
            return new RegionDetail();

        }


        public async Task<List<RegionDetail>> GetAllInformationByProvince(string regionName, string iso)
        {
            RegionDetailData result = await GetByRegion(regionName, iso);
            if (result.Data.Any())
            {
                var resultByProvince = result.Data.GroupBy(x => x.Region.Province)
                .Select(region => new RegionDetail
                {
                    Deaths = region.Sum(re => re.Deaths),
                    Confirmed = region.Sum(re => re.Confirmed),
                    Region = region.First().Region,                    
                }).ToList();

                return resultByProvince;
            }
            return new List<RegionDetail>();

        }

        private static async Task<RegionDetailData> GetByRegion(string regionName, string iso)
        {
            var client = new HttpClient();
            RegionDetailData result = new RegionDetailData();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://covid-19-statistics.p.rapidapi.com/reports?region_name={regionName}&iso={iso}"),
                Headers =
                {
                    { "x-rapidapi-key", "f0185dd5camsh97364112a79dff9p1eed3djsn952cd7344b3d" },
                    { "x-rapidapi-host", "covid-19-statistics.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                result = JsonConvert.DeserializeObject<RegionDetailData>(body);

            }

            return result;
        }

        public async Task<List<RegionDetailDTO>> GetAll()
        {
            var regions = await GetAllRegions();
            List<RegionDetail> regionData = new List<RegionDetail>();
            foreach (var region in regions.Data) 
            {
                var regionInformation = await GetAllInformationByRegion(region.Name,region.Iso);
                regionData.Add(regionInformation);
            }

            regionData = regionData.OrderByDescending(x => x.Confirmed).Take(10).ToList();
           
            var detail = RegionDetailDTO.FromModelToDTOByRegion(regionData);
            return detail.ToList();

        }

        public async Task<List<RegionDetailDTO>> GetAllByProvince(string name, string iso)
        {
            List<RegionDetail> regionData = new List<RegionDetail>();
            var regionInformation = await GetAllInformationByProvince(name, iso);
            regionData.AddRange(regionInformation);
            regionData = regionData.OrderByDescending(x => x.Confirmed).Take(10).ToList();
            var detail = RegionDetailDTO.FromModelToDTOByProvince(regionData);
            return detail.ToList();

        }
    }


}

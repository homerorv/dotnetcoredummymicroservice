using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DummyMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoryStressController : ControllerBase
    {

        static byte[] _memoryholder = new byte[10];

        [HttpGet]
        public double Get(long megaBytes,bool release)
        {
            double mem = 0;
            mem = StressMemory(megaBytes);
            if(release == true)
            {
                mem = ReleaseMemory();
            }
            return mem;
        }

        static double StressMemory(long megaBytes)
        {

            if (megaBytes > 0)
            {
                _memoryholder = new byte[megaBytes * 1024 * 1024];  //dummy allocation of memory
            }
            var memInBytes = GC.GetTotalMemory(false);

            var menInMega = ConvertBytesToMegabytes(memInBytes);

            return menInMega;

        }

        static double ReleaseMemory()
        {
             _memoryholder = new byte[0];

            GC.Collect();
            var memInBytes = GC.GetTotalMemory(true);
            var menInMega = ConvertBytesToMegabytes(memInBytes);

            return menInMega;
        }


        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

    }
}

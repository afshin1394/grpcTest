using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System;

using Grpc.Core;
namespace serviceTest.Protos
{
    class MoshtaryImpl : MoshtaryService.MoshtaryServiceBase
    {

        // Server side handler of the GetMoshtary 
        public override Task<MoshtaryList> GetMoshtaryByccMasir(MoshtaryRequest request, ServerCallContext context)
        {
            MoshtaryDAO moshtaryDao = new MoshtaryDAO();
            
     
            return Task.FromResult(moshtaryDao.GetMoshtaryByccMasir(request));

        }


        // Server side handler of the insertMoshtary 
     //   public override Task<Moshtary> Insert(Moshtary request, ServerCallContext context)
     // {
     //     MoshtaryDAO moshtaryDao = new MoshtaryDAO();
     //
     //     return Task.FromResult(moshtaryDao.insertMoshtary(request));
     //
     // }

    }
}
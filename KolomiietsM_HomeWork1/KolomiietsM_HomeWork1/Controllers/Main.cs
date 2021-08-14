using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Main : ControllerBase
    {
            public ISaveService saveService;
            public MainLogicService mainLogicService;
            public CheckService checkService;
            public IContentService contentService;
            public PublicService publicService;
        public Main(ISaveService saveService, MainLogicService mainLogicService, CheckService checkService, IContentService contentService, PublicService publicService)
        {
            this.saveService = saveService;
            this.mainLogicService = mainLogicService;
            this.checkService = checkService;
            this.contentService = contentService;
            this.publicService = publicService;
        }

        [HttpGet]
        public string Get()
        {
            checkService.check();
            mainLogicService.doMainLogic();
            saveService.save();
            contentService.makeContent();
            publicService.publish();

            return "Hello";
        }
    }
}

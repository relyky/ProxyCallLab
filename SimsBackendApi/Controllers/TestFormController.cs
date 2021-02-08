using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimsBackendApi.Controllers
{
    #region DTO
    public class FormInfo
    {
        public string formNo { get; set; }
        public string anString { get; set; }
        public decimal anNumber { get; set; }
        public DateTime anTime { get; set; }
    }
    #endregion

    [ApiController]
    [Route("[controller]")]
    public class TestFormController : ControllerBase
    {
        private static List<FormInfo> formList = new List<FormInfo>() {
            new FormInfo {
                formNo = "F001",
                anString = "表單一號",
                anNumber = 10001,
                anTime = DateTime.Now
            },
            new FormInfo {
                formNo = "F002",
                anString = "表單二號",
                anNumber = 20001,
                anTime = DateTime.Now.AddMinutes(2)
            },
            new FormInfo
            {
                formNo = "F003",
                anString = "表單三號",
                anNumber = 30001,
                anTime = DateTime.Now.AddMinutes(3)
            },
        };

        private readonly ILogger<TestFormController> _logger;

        public TestFormController(ILogger<TestFormController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("[action]")]
        public IEnumerable<FormInfo> QueryForm()
        {
            return formList;
        }

        [HttpPost("[action]")]
        public FormInfo LoadForm(string formNo)
        {
            var info = formList.FirstOrDefault(c => c.formNo == formNo);
            if (info != null)
                return info;

            throw new ApplicationException("查無此筆資料。");
        }

        [HttpPost("[action]")]
        public FormInfo SaveForm(FormInfo formData)
        {
            var info = formList.FirstOrDefault(c => c.formNo == formData.formNo);
            if (info != null)
                formList.Remove(info);

            formData.anTime = DateTime.Now;
            formList.Add(formData);

            return formData;
        }

        [HttpPost("[action]")]
        public ErrMsg LongTimeCalc(int spend)
        {
            if (spend < 0) throw new Exception("測試用例外！");

            if (spend < 3) spend = 3;
            if (spend > 10) spend = 10;

            DateTime now = DateTime.Now;
            System.Threading.SpinWait.SpinUntil(() => false, spend * 1000); // 等n秒
            var duration = DateTime.Now.Subtract(now);

            return new ErrMsg {
                errType = "SUCCESS",
                errMsg = $"共花費時間{duration}。"
            };
        }

    }

}

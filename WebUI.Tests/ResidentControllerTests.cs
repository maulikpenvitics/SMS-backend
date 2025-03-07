
using Domain.Entities;
using System.Web.Mvc;
using WebUI.Models;
using System.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using Moq;
using System.Web.Routing;
using WebUI.Controllers;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace WebUI.Tests
{
    [TestClass]
    public class ResidentControllerTests
    {
       [TestMethod]
       public void TestResidentModule()
       {
            string RootPath = ConfigurationManager.AppSettings["Root"];
            string ResultTest = string.Empty;
            string StrDate = DateTime.Now.ToShortDateString();
            string ModuleName = "Resident";
            string ListStatus = string.Empty;
            string CreateActionStatus = string.Empty;
            try
            {
                var mockSession = new Mock<HttpSessionStateBase>();
                mockSession.Setup(f => f["UserId"]).Returns(() => "1");
                var mockContext = new Mock<HttpContextBase>();
                mockContext.Setup(f => f.Session).Returns(mockSession.Object);
                 
                ResidentController controller = new ResidentController();

                controller.ControllerContext = new ControllerContext()
                {
                    Controller = controller,
                    RequestContext = new RequestContext(mockContext.Object, new RouteData())
                };
                ResidentFilter Filter = new ResidentFilter();
                /////////////////Start List Testcase/////////////////

                var ListResult = controller.List(Filter) as ViewResult;
                Assert.IsNotNull(ListResult);
                ListStatus = "Passed";
                /////////////////End List Testcase/////////////////


                /////////////////Start Create Action Testcase/////////////////

                var CreateResult = controller.Create() as ViewResult;
                Assert.IsNotNull(CreateResult);
                CreateActionStatus = "Passed";
                /////////////////End Create Action Testcase/////////////////

                 /////////////////Start Create Object process for insert Testcase/////////////////
                 List<Resident> ResidentObj = new List<Resident>();
                using (StreamReader r = new StreamReader(RootPath+ "Request/Resident/Request.json"))
                {
                    string json = r.ReadToEnd();
                    ResidentObj = JsonConvert.DeserializeObject<List<Resident>>(json);
                }
                /////////////////End Create Object process for insert Testcase/////////////////
                 int ModelCounter = 0;
                foreach (var ResidentItem in ResidentObj)
                {
                    ModelCounter++;
                    ResultTest += StrDate + "," + ModelCounter + "," + ModuleName + "," + ListStatus;
                    /////////////////Start Process submit Object for insert Testcase/////////////////
                    var CreateSubmitResult = controller.Submit(ResidentItem) as ViewResult;
                    Assert.IsTrue(ResidentItem.Id > 0);
                    ResultTest += ",Passed";
                    /////////////////End Process submit Object for insert Testcase/////////////////


                    /////////////////Start Process for getbyIs Testcase/////////////////
                    var EditResult = controller.Edit(ResidentItem.Id) as ViewResult;
                    Assert.IsTrue(ResidentItem.Id > 0);
                    ResultTest += ",Passed";
                    /////////////////End Process for getbyIs Testcase/////////////////

                    /////////////////Start Process for Update Testcase/////////////////
                    var UpdateSubmitResult = controller.Submit(ResidentItem) as ViewResult;
                    Assert.IsTrue(ResidentItem.Id > 0);
                    ResultTest += ",Passed";
                    /////////////////End Process for Update Testcase/////////////////


                    /////////////////Start Process for delete Testcase/////////////////
                    var DeleteResult = controller.Delete(ResidentItem.Id) as ViewResult;
                    Assert.IsTrue(ResidentItem.Id > 0);
                    ResultTest += ",Passed";
                    /////////////////End Process for delete Testcase/////////////////
                     ResultTest += ",Passed";
                    ResultTest += ","+ ResidentItem.Id+"\n";
                }

                /////////////////End Process for delete Testcase/////////////////
               
           
            }
            finally
            {
                if (!File.Exists(RootPath + "Output//Result.csv"))
                {
                    File.WriteAllText(RootPath + "Output//Result.csv", "Date,JsonNo,Module,List,Create,GetById,Edit,Delete,Final,RequestId\n");
                }
                 ResultTest += "\n";
                File.AppendAllText(RootPath + "Output//Result.csv", ResultTest.ToString());
            }
           
       }
    }
}
   



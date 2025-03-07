
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
    public class PropertyVendorsControllerTests
    {
       [TestMethod]
       public void TestPropertyVendorsModule()
       {
            string RootPath = ConfigurationManager.AppSettings["Root"];
            string ResultTest = string.Empty;
            string StrDate = DateTime.Now.ToShortDateString();
            string ModuleName = "PropertyVendors";
            string ListStatus = string.Empty;
            string CreateActionStatus = string.Empty;
            try
            {
                var mockSession = new Mock<HttpSessionStateBase>();
                mockSession.Setup(f => f["UserId"]).Returns(() => "1");
                var mockContext = new Mock<HttpContextBase>();
                mockContext.Setup(f => f.Session).Returns(mockSession.Object);
                 
                PropertyVendorsController controller = new PropertyVendorsController();

                controller.ControllerContext = new ControllerContext()
                {
                    Controller = controller,
                    RequestContext = new RequestContext(mockContext.Object, new RouteData())
                };
                PropertyVendorsFilter Filter = new PropertyVendorsFilter();
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
                 List<PropertyVendors> PropertyVendorsObj = new List<PropertyVendors>();
                using (StreamReader r = new StreamReader(RootPath+ "Request/PropertyVendors/Request.json"))
                {
                    string json = r.ReadToEnd();
                    PropertyVendorsObj = JsonConvert.DeserializeObject<List<PropertyVendors>>(json);
                }
                /////////////////End Create Object process for insert Testcase/////////////////
                 int ModelCounter = 0;
                foreach (var PropertyVendorsItem in PropertyVendorsObj)
                {
                    ModelCounter++;
                    ResultTest += StrDate + "," + ModelCounter + "," + ModuleName + "," + ListStatus;
                    /////////////////Start Process submit Object for insert Testcase/////////////////
                    var CreateSubmitResult = controller.Submit(PropertyVendorsItem) as ViewResult;
                    Assert.IsTrue(PropertyVendorsItem.Id > 0);
                    ResultTest += ",Passed";
                    /////////////////End Process submit Object for insert Testcase/////////////////


                    /////////////////Start Process for getbyIs Testcase/////////////////
                    var EditResult = controller.Edit(PropertyVendorsItem.Id) as ViewResult;
                    Assert.IsTrue(PropertyVendorsItem.Id > 0);
                    ResultTest += ",Passed";
                    /////////////////End Process for getbyIs Testcase/////////////////

                    /////////////////Start Process for Update Testcase/////////////////
                    var UpdateSubmitResult = controller.Submit(PropertyVendorsItem) as ViewResult;
                    Assert.IsTrue(PropertyVendorsItem.Id > 0);
                    ResultTest += ",Passed";
                    /////////////////End Process for Update Testcase/////////////////


                    /////////////////Start Process for delete Testcase/////////////////
                    var DeleteResult = controller.Delete(PropertyVendorsItem.Id) as ViewResult;
                    Assert.IsTrue(PropertyVendorsItem.Id > 0);
                    ResultTest += ",Passed";
                    /////////////////End Process for delete Testcase/////////////////
                     ResultTest += ",Passed";
                    ResultTest += ","+ PropertyVendorsItem.Id+"\n";
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
   



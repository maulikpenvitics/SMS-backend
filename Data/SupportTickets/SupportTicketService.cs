using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Data.SupportTickets;
using Data.Services;
using Data.Vendors;
using Data.Users;

namespace Data.SupportTickets
{
    public interface ISupportTicketService
    {
        List<SupportTicketResponseModel> GetSupportTickets();
        SupportTicket GetSupportTicket(int Id);
        void CreateSupportTicket(SupportTicket SupportTicketObj);
        void UpdateSupportTicket(SupportTicket SupportTicketObj);
        bool DeleteSupportTicket(int Id);
       // List<SelectListItem> GetSupportTicketDropdown();

    }
    public class SupportTicketService : ISupportTicketService
    {

        private readonly IServiceRepository _serviceRepository = new ServiceRepository(new DbFactory());
        private readonly IVendorRepository _vendorRepository = new VendorRepository(new DbFactory());
        private readonly ISupportTicketRepository _supportticketRepository = new SupportTicketRepository(new DbFactory());
        private readonly IUserRepository _userRepository = new UserRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());

        public List<SupportTicketResponseModel> GetSupportTickets()
        {
            var SupportTicketList = (
                                       from _supportticket in _supportticketRepository.GetAll()
                         join _service in _serviceRepository.GetAll() on _supportticket.ServiceId equals _service.Id
                          join _vendor in _vendorRepository.GetAll() on _supportticket.VendorId equals _vendor.Id
                          join _user in _userRepository.GetAll() on _supportticket.UserId equals _user.Id

                                       select new SupportTicketResponseModel
                                       {
                                           Id = _supportticket.Id,
                                           UserId = _user.Id,
                                           Username = _user.Username,
                                           Ticket = _supportticket.Ticket,
                                           Description = _supportticket.Description,
                                           Severity = _supportticket.Severity,
                                           Duedate = _supportticket.Duedate,
                                           ServiceId = _service.Id,
                                           Servicename = _service.Name,
                                           Status = _supportticket.Status,
                                           Comment = _supportticket.Comment,
                                           VendorEmployeeId = _supportticket.VendorEmployeeId,
                                           VendorId = _vendor.Id,
                                           Vendorname = _vendor.Firstname+" "+ _vendor.Lastname,
                                           Modifiedby = _supportticket.Modifiedby,
                                           Modifieddate = _supportticket.Modifieddate,


                                       }).ToList();
            return SupportTicketList;


        }
        public SupportTicket GetSupportTicket(int Id)
        {
            var Result = _supportticketRepository.GetById(Id);
            return Result;
        }
        public void CreateSupportTicket(SupportTicket SupportTicketObj)
        {
            _supportticketRepository.Add(SupportTicketObj);
        }
        public void UpdateSupportTicket(SupportTicket SupportTicketObj)
        {
            _supportticketRepository.Update(SupportTicketObj);
        }

        public bool DeleteSupportTicket(int Id)
        {
            var Result = _supportticketRepository.GetById(Id);
            _supportticketRepository.Delete(Result);
            return true;
        }
        //public List<SelectListItem> GetSupportTicketDropdown()
        //{
        //    var Result = _supportticketRepository.GetAll().Select(x => new SelectListItem
        //    {
        //        Value = x.Id.ToString(),
        //        Text = x.Name.ToString()

        //    }).ToList();
        //    return Result;
        //}

    }
}




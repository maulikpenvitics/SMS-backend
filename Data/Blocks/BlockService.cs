 using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 using Data.Propertys;
 using Data.Blocks;


namespace Data.Blocks
{
     public interface IBlockService
    {
        List<BlockResponseModel> GetBlocks();
        Block GetBlock(int Id);
        void CreateBlock(Block BlockObj);
        void UpdateBlock(Block BlockObj);
        bool DeleteBlock(int Id);
        List<SelectListItem> GetBlockDropdown();
         
    }
    public class BlockService : IBlockService
    {
        
         private readonly IPropertyRepository _propertyRepository = new PropertyRepository(new DbFactory());
 private readonly IBlockRepository _blockRepository = new BlockRepository(new DbFactory());

        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new DbFactory());
        
        public List<BlockResponseModel> GetBlocks()
        {
                var BlockList = (
                                           from _block in _blockRepository.GetAll()
 join  _property in _propertyRepository.GetAll() on  _block.PropertyId equals _property.Id

                                          select new BlockResponseModel
                                          {
                                               Id = _block.Id,
Blockname = _block.Blockname,
PropertyId = _property.Id,
PropertyName = _property.Propertyname,
Modifiedby = _block.Modifiedby,
Modifieddate = _block.Modifieddate,


                                          }).ToList();
                    return BlockList;
            

        }
        public Block GetBlock(int Id)
        {
            var Result = _blockRepository.GetById(Id);
            return Result;
        }
        public void CreateBlock(Block BlockObj)
        {
            _blockRepository.Add(BlockObj);
        }
        public void UpdateBlock(Block BlockObj)
        {
            _blockRepository.Update(BlockObj);
        }

        public bool DeleteBlock(int Id)
        {
            var Result = _blockRepository.GetById(Id);
            _blockRepository.Delete(Result);
            return true;
        }
        public List<SelectListItem> GetBlockDropdown()
        {
            var Result = _blockRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString() ,
                Text = x.Blockname.ToString() 

            }).ToList();
            return Result;
        }
         
    }
}
   



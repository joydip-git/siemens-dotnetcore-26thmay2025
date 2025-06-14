﻿using Siemens.DotNetCore.PmsApp.DataAccessLayer;
using Siemens.DotNetCore.PmsApp.Entities;

namespace Siemens.DotNetCore.PmsApp.BusinessLayer
{
    public class ProductBo(IPmsDao<ProductDto, string> pmsDao) : IPmsBusinessComponent<ProductDto, string>
    {
        //private readonly IPmsDao<ProductDto, string> pmsDao;
        //public ProductBo(IPmsDao<ProductDto, string> pmsDao)
        //{
        //    this.pmsDao = pmsDao;
        //}

        public ProductDto? Add(ProductDto entity)
        {
            return null;
        }

        public IEnumerable<ProductDto> FetchAll()
        {
            try
            {
                var records = pmsDao.GetAll();
                return records.Any() ? records : throw new Exception("no records found");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProductDto? FetchById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new ArgumentException($"{nameof(id)} is either null or empty");
                else
                    return pmsDao.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProductDto? Modify(string id, ProductDto entity)
        {
            return null;
        }

        public ProductDto? Remove(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new ArgumentException($"{nameof(id)} is either null or empty");
                else
                    return pmsDao.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

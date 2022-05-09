using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Api.AccessLayer;
using ShopApp.Api.AccessLayer.Repositories.Concretes;
using ShopApp.Api.BusinessLayer.ManagerServices.Abstracts;
using ShopApp.Api.BusinessLayer.ProductOperations.CreateProduct;
using ShopApp.Api.BusinessLayer.ProductOperations.DeleteProduct;
using ShopApp.Api.BusinessLayer.ProductOperations.GetProduct;
using ShopApp.Api.BusinessLayer.ProductOperations.GetProductDetail;
using ShopApp.Api.BusinessLayer.ProductOperations.UpdateProduct;
using static ShopApp.Api.BusinessLayer.ProductOperations.CreateProduct.CreateProductCommand;

namespace ShopApp.Api.UI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ProductController : Controller 
    {


        IProductManager _pMan;
        private readonly IMapper _mapper;

        public ProductController(IProductManager pMan, IMapper mapper)
        {
            _pMan = pMan;
            _mapper = mapper;
        }
       

        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = _pMan.GetActives();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ProductDetailViewModel result;
            try
            {
                GetProductDetailQuery query = new GetProductDetailQuery(_pMan, _mapper);
                query.ProductId = id;
                GetProductValidator validator = new GetProductValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] CreateProductModel newProduct)
        {
            CreateProductCommand command = new CreateProductCommand(_pMan, _mapper);
            try
            {
                command.Model = newProduct;
                CreateProductCommandValidator validator = new CreateProductCommandValidator();

                validator.ValidateAndThrow(command);


                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductModel updatedProduct)
        {
            try
            {
                UpdateProductCommand command = new UpdateProductCommand(_pMan);
                command.ProductId = id;
                command.Model = updatedProduct;

                UpdateProductValidator validator = new UpdateProductValidator();
                validator.ValidateAndThrow(command);

                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult DeletedProduct(int id)
        {
            try
            {
                DeleteProductCommand command = new DeleteProductCommand(_pMan);
                command.ProductId = id;
                DeleteProductCommandValidator validator = new DeleteProductCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }



    }
}

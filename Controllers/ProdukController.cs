using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using UTS_Project_ViraNarullita.Models;
using UTS_Project_ViraNarullita.Models.DTO;
using UTS_Project_ViraNarullita.Services;
using UTS_Project_ViraNarullita.Validator;

namespace UTS_Project_ViraNarullita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdukController : ControllerBase
    {
        private readonly ProdukService _produkService;
        private ValidationResult _validation;

        public ProdukController(ProdukService ProdukService)
        {
            _produkService = ProdukService;
        }

        // GET: api/<ProdukController>
        [HttpGet("list")]
        public IActionResult Get()
        {
            try
            {
                var ProduksList = _produkService.GetListProduk();
                var response = new GeneralResponse
                {
                    StatusCode = "01",
                    StatusDesc = "Success",
                    Data = ProduksList
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new GeneralResponse
                {
                    StatusCode = "99",
                    StatusDesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };
                return BadRequest(response);
            }
        }


        // POST api/<ProdukController>
        [HttpPost("create")]
        public IActionResult Post(ProdukRequestDTO Produk)
        {
            try
            {
                ValidatorRequestProduk request = new ValidatorRequestProduk();
                _validation = request.Validate(Produk);

                if (_validation.IsValid)
                {
                    var insertProduk = _produkService.CreateProduk(Produk);
                    if (insertProduk)
                    {
                        var ResponseSuccess = new GeneralResponse
                        {
                            StatusCode = "01",
                            StatusDesc = "Insert Produk Succes",
                            Data = Produk
                        };
                        return Ok(ResponseSuccess);
                    }

                    var ResponseFailed = new GeneralResponse
                    {
                        StatusCode = "02",
                        StatusDesc = "Insert Produk Failed",
                        Data = Produk
                    };
                    return BadRequest(ResponseFailed);
                }
                else
                {
                    var ResponseFailed = new GeneralResponse
                    {
                        StatusCode = "02",
                        StatusDesc = _validation.ToString(),
                        Data = Produk
                    };
                    return BadRequest(ResponseFailed);
                }
            }
            catch (Exception ex)
            {
                var responseFailed = new GeneralResponse
                {
                    StatusCode = "99",
                    StatusDesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };
                return BadRequest(responseFailed);
            }
        }

        // PUT api/<ProdukController>/5
        [Route("Update")]
        [HttpPut]
        public IActionResult Put(int Id, ProdukRequestDTO Produk)
        {
            try
            {
                ValidatorRequestProduk updateRequest = new ValidatorRequestProduk();
                _validation = updateRequest.Validate(Produk);

                if (_validation.IsValid)
                {
                    var updateProduk = _produkService.UpdateProduk(Id, Produk);
                    if (updateProduk)
                    {
                        var responseSucces = new GeneralResponse
                        {
                            StatusCode = "01",
                            StatusDesc = "Update Produk Succes",
                            Data = null
                        };
                        return Ok(responseSucces);
                    }

                    var responseFailed = new GeneralResponse
                    {
                        StatusCode = "02",
                        StatusDesc = "Insert Produk Failed",
                        Data = null
                    };
                    return BadRequest(responseFailed);
                }
                else
                {
                    var responseFailed = new GeneralResponse
                    {
                        StatusCode = "02",
                        StatusDesc = _validation.ToString(),
                        Data = null
                    };
                    return BadRequest(responseFailed);
                }
            }
            catch (Exception ex)
            {
                var responseFailed = new GeneralResponse
                {
                    StatusCode = "99",
                    StatusDesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };
                return BadRequest(responseFailed);
            }
        }

        // DELETE api/<ProdukController>/5
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                var deleteProduk = _produkService.DeleteProduk(id);
                if (deleteProduk)
                {
                    var responseSucces = new GeneralResponse
                    {
                        StatusCode = "01",
                        StatusDesc = "Delete Produk Succes",
                        Data = null
                    };
                    return Ok(responseSucces);
                }

                var responseFailed = new GeneralResponse
                {
                    StatusCode = "02",
                    StatusDesc = "Data tidak ditemukan",
                    Data = null
                };
                return NotFound(responseFailed);
            }
            catch (Exception ex)
            {
                var responseFailed = new GeneralResponse
                {
                    StatusCode = "99",
                    StatusDesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };
                return BadRequest(responseFailed);
            }
        }
    }
}
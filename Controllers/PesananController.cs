using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using UTS_Project_ViraNarullita.Models;
using UTS_Project_ViraNarullita.Models.DTO;
using UTS_Project_ViraNarullita.Services;
using UTS_Project_ViraNarullita.Validator;

namespace UTS_project_ViraNarullita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesananController : ControllerBase
    {
        private readonly PesananService _pesananService;
        private ValidationResult _validation;

        public PesananController(PesananService PesananService)
        {
            _pesananService = PesananService;
        }

        // GET: api/<PesananController>
        [HttpGet("list")]
        public IActionResult Get()
        {
            try
            {
                var PesanansList = _pesananService.GetListPesanan();
                var response = new GeneralResponse
                {
                    StatusCode = "01",
                    StatusDesc = "Success",
                    Data = PesanansList
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

        // GET api/<PesananController>/5
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var PesananData = _pesananService.GetById(id);
                if (PesananData != null)
                {
                    var response = new GeneralResponse
                    {
                        StatusCode = "01",
                        StatusDesc = "Success",
                        Data = PesananData
                    };
                    return Ok(response);
                }

                var responseFailed = new GeneralResponse
                {
                    StatusCode = "02",
                    StatusDesc = "Pesanan not found",
                    Data = null
                };
                return NotFound(responseFailed);
            }
            catch (Exception ex)
            {
                var errorResponse = new GeneralResponse
                {
                    StatusCode = "99",
                    StatusDesc = "Failed | " + ex.Message,
                    Data = null
                };
                return BadRequest(errorResponse);
            }
        }

        // POST api/<PesananController>
        [HttpPost("create")]
        public IActionResult Post(PesananRequestDTO Pesanan)
        {
            try
            {
                ValidatorRequestPesanan request = new ValidatorRequestPesanan();
                _validation = request.Validate(Pesanan);

                if (_validation.IsValid)
                {
                    var insertPesanan = _pesananService.CreatePesanan(Pesanan);
                    if (insertPesanan)
                    {
                        var ResponseSuccess = new GeneralResponse
                        {
                            StatusCode = "01",
                            StatusDesc = "Insert Pesanan Succes",
                            Data = Pesanan
                        };
                        return Ok(ResponseSuccess);
                    }

                    var ResponseFailed = new GeneralResponse
                    {
                        StatusCode = "02",
                        StatusDesc = "Insert Pesanan Failed",
                        Data = Pesanan
                    };
                    return BadRequest(ResponseFailed);
                }
                else
                {
                    var ResponseFailed = new GeneralResponse
                    {
                        StatusCode = "02",
                        StatusDesc = _validation.ToString(),
                        Data = Pesanan
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

        // PUT api/<PesananController>/5
        [Route("Update")]
        [HttpPut]
        public IActionResult Put(int Id, PesananRequestDTO Pesanan)
        {
            try
            {
                ValidatorRequestPesanan updateRequest = new ValidatorRequestPesanan();
                _validation = updateRequest.Validate(Pesanan);

                if (_validation.IsValid)
                {
                    var updatePesanan = _pesananService.UpdatePesanan(Id, Pesanan);
                    if (updatePesanan)
                    {
                        var responseSucces = new GeneralResponse
                        {
                            StatusCode = "01",
                            StatusDesc = "Update Pesanan Succes",
                            Data = null
                        };
                        return Ok(responseSucces);
                    }

                    var responseFailed = new GeneralResponse
                    {
                        StatusCode = "02",
                        StatusDesc = "Insert Pesanan Failed",
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

        // DELETE api/<PesananController>/5
        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                var deletePesanan = _pesananService.DeletePesanan(id);
                if (deletePesanan)
                {
                    var responseSucces = new GeneralResponse
                    {
                        StatusCode = "01",
                        StatusDesc = "Delete Pesanan Succes",
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

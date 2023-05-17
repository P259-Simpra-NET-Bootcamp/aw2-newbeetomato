using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OdevData.Domain;
using OdevData.Repository;
using Odev2Schema;
using OdevData.Repository.Staffs;
using Odev2Schema.Staff;
using System.ComponentModel.DataAnnotations;
using Odev2Service.Validataions;


namespace Odev2Service.Controllers;

[Route("OdevApi/[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
    private readonly IStaffRepository _staffRepository;
    private IMapper _mapper;

    public StaffController(IMapper mapper, IStaffRepository staffRepository)
    {
        _mapper = mapper;
        _staffRepository = staffRepository;
    }
    [HttpGet]
    public ActionResult<List<StaffResponse>> GetAll()
    {
        var query = _staffRepository.GetAll();
        var mapped = _mapper.Map<List<StaffResponse>>(query);
        return Ok(mapped);
    }
    [HttpGet("filter/{firstNameFilter}")]
    public ActionResult<List<StaffResponse>> GetAll(string firstNameFilter)
    {
        var staffs = _staffRepository.GetStaffsByCriteria(firstNameFilter);

        var mapped = _mapper.Map<List<StaffResponse>>(staffs);
        return Ok(mapped);
    }

    [HttpGet("{id}")]
    public StaffResponse GetById(int id)
    {
        var row = _staffRepository.GetById(id);

        var mapped = _mapper.Map<Staff, StaffResponse>(row);
        return mapped;
    }

    [HttpPost]
    public ActionResult<StaffResponse> Post([FromBody] StaffRequest request)
    {
        StaffRequestValidator validator = new StaffRequestValidator();
        FluentValidation.Results.ValidationResult validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var entity = _mapper.Map<Staff>(request);
        _staffRepository.Insert(entity);
        _staffRepository.Complete();

        var mapped = _mapper.Map<Staff, StaffResponse>(entity);
        return Ok(mapped);
    }


    [HttpPut("{id}")]
    public ActionResult<StaffResponse> Put(int id, [FromBody] StaffRequest request)
    {
        request.Id = id;
        StaffRequestValidator validator = new StaffRequestValidator();
        FluentValidation.Results.ValidationResult validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var staff = _staffRepository.GetById(id);

        if (staff == null)
        {
            return NotFound();
        }

        _mapper.Map(request, staff);
        _staffRepository.Update(staff);
        _staffRepository.Complete();

        var response = _mapper.Map<StaffResponse>(staff);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var staff = _staffRepository.GetById(id);

        if (staff == null)
        {
            return NotFound();
        }

        _staffRepository.Delete(staff);
        _staffRepository.Complete();

        return NoContent();
    }




}


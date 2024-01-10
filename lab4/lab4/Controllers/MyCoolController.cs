using lab4.Calendar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MyCoolController : ControllerBase
{
    private readonly Storage _storage;

    public MyCoolController(Storage storage)
    {
        _storage = storage;
    }

    [HttpGet("Load from SQL")]
    public ActionResult<IEnumerable<IActionResult>> GetFromSqlite()
    {
        var tasks = _storage.LoadFromSqLite();
        return Ok(tasks);
    }

    [HttpPost("Save to Sqlite")]
    public ActionResult SaveToSqlite([FromBody] List<QueryInformation> tasks)
    {
        _storage.SaveToSqLite(tasks);
        return Ok();
    }
    
    [HttpGet("Load from XML")]
    public ActionResult<IEnumerable<IActionResult>> GetFromXml()
    {
        var queries = _storage.LoadFromXml();
        return Ok(queries);
    }

    [HttpPost("Save to XML")]
    public ActionResult SaveToXml([FromBody] List<QueryInformation> queries)
    {
        _storage.SaveToXml(queries);
        return Ok();
    }
    
    [HttpGet("Load from JSON")]
    public ActionResult<IEnumerable<IActionResult>> GetFromJson()
    {
        var queries = _storage.LoadFromJson();
        return Ok(queries);
    }
    
    [HttpPost("Save to JSON")]
    public ActionResult SaveToJson([FromBody] List<QueryInformation> queries)
    {
        _storage.SaveToJson(queries);
        return Ok();
    }
}
// <copyright file="StudentsController.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Controllers;

using CRM.Data;
using CRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private QcContext qcContext;

    public StudentsController(QcContext qcContext)
    {
        this.qcContext = qcContext;
    }

    /// <summary>
    /// Gets a student by id.
    /// </summary>
    /// <param name="id">The student's id.</param>
    /// <returns>The student.</returns>
    [HttpGet]
    public async Task<ActionResult<Student>> GetStudent(uint id)
    {
        var student = await this.qcContext.Students
            .Include(s => s.Enrollments)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (student == null)
        {
            return this.NotFound();
        }

        return student;
    }
}

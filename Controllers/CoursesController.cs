using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEduPlatform.Data;
using OnlineEduPlatform.Models;

namespace OnlineEduPlatform.Controllers;

public class CoursesController : Controller
{
    private readonly AppDbContext _context;

    public CoursesController(AppDbContext context) => _context = context;

    // GET: /Courses
    public async Task<IActionResult> Index()
    {
        var courses = await _context.Courses
            .Include(c => c.Teacher)
            .Include(c => c.Students)
            .ToListAsync();
        return View(courses);
    }

    // GET: /Courses/Create
    public IActionResult Create()
    {
        ViewBag.Teachers = _context.Teachers.ToList();
        return View();
    }

    // POST: /Courses/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Course course)
    {
        if (ModelState.IsValid)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Teachers = _context.Teachers.ToList();
        return View(course);
    }

    // GET: /Courses/Enroll/Id
    public async Task<IActionResult> Enroll(int id)
    {
        var course = await _context.Courses
            .Include(c => c.Students)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (course == null) return NotFound();

        var enrolledStudents = course.Students.Select(s => s.Id).ToList();

        ViewBag.Students = _context.Students
            .Where(s=> !enrolledStudents.Contains(s.Id))
            .ToList();
        ViewBag.Course = course;
        return View();
    }

    // POST: /Courses/Enroll/Id
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Enroll(int id, int studentId)
    {
        var course = await _context.Courses
            .Include(c => c.Students)
            .FirstOrDefaultAsync(c => c.Id == id);
        var student = await _context.Students.FindAsync(studentId);

        if (course == null || student == null) return NotFound();

        if (!course.Students.Any(s => s.Id == studentId))
        {
            course.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Details), new { id=id});
    }

    // GET: /Courses/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var course = await _context.Courses
            .Include(c => c.Teacher)
            .Include(c => c.Students)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (course == null) return NotFound();

        return View(course);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var course = await _context.Courses
            .FirstOrDefaultAsync(c => c.Id == id);

        if (course == null) return NotFound();

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
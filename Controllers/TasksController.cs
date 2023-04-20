using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TOTVS_Challenge.Models;

namespace TOTVS_Challenge.Controllers
{
    public class TasksController : Controller
    {
        private readonly TOTVSDbContext _context;

        public TasksController(TOTVSDbContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
              return _context.Tasks != null ? 
                          View(await _context.Tasks.ToListAsync()) :
                          Problem("Entity set 'TOTVSDbContext.Tasks'  is null.");
        }     

        // GET: Tasks/CreateOrEdit
        public IActionResult CreateOrEdit(int id = 0)
        {
            if(id == 0)
                return View(new Tasks());
            else
                return View(_context.Tasks.Find(id));

        }

        // POST: Tasks/CreateOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit([Bind("TaskId,Title,Description,CreationDate,ConclusionDate,status,responsibleUserId")] Tasks task)
        {   
            if (ModelState.IsValid)
            {
                var users = _context.Users.FirstOrDefault(r => r.UserId == task.responsibleUserId);
                if(users != null)
                {
                    if (users.AssignedTasks != null)
                        users.AssignedTasks += ", " + task.Title;
                    else
                        users.AssignedTasks = task.Title;
                }
                else
                {
                    task.responsibleUserId = null;
                }
                  
                if (task.TaskId == 0)
                {
                    task.CreationDate = DateTime.Now;
                    task.status = "Unfinished";
                    _context.Add(task);
                } else
                {
                    _context.Update(task);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // POST: Tasks/MakeTaskDoneOrUndone
        [HttpPost, ActionName("MakeTaskDoneOrUndone")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MakeTaskDoneOrUndone(int id)
        {
            var checkTask = await _context.Tasks.FindAsync(id);
            if (checkTask.status == "Unfinished")
            { //Could have made status a boolean, but preferred to keep as string to cover other possible status
                checkTask.status = "Finished";
                checkTask.ConclusionDate = DateTime.Now;
            }
            else if (checkTask.status == "Finished")
            {
                checkTask.status = "Unfinished";
                checkTask.ConclusionDate = null;
            }
                
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

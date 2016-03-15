﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BrewrMVC.Models
{
    public class BrewRepository : IBrewRepository
    {
        string userid = HttpContext.Current.User.Identity.GetUserId();

        //private IBrewContext context;

        //public BrewRepository()
        //{
        //    context = new BrewContext();
        //}

        //public BrewRepository(IBrewContext brewContext)
        //{
        //    context = brewContext;
        //}

        public List<Brew> GetAllWhereComplete()
        {
            using (var context = new BrewContext())
            {
                var brews = context.Brews
                    .Where(x => x.UserId == userid && x.Complete == true)
                    .ToList();
                return brews;
            }
        }

        public List<Brew> GetAllWhereInComplete()
        {
            using (var context = new BrewContext())
            {
                var brews = context.Brews
                    .Where(x => x.UserId == userid && x.Complete == false)
                    .ToList();
                return brews;
            }
        }

        public void AddNewBrew(Brew brew)
        {
            using (var context = new BrewContext())
            {
                var newbrew = brew;
                newbrew.UserId = userid;
                context.Brews.Add(newbrew);
                context.SaveChanges();
            }
        }

        public Brew FindById(int id)
        {
            using (var context = new BrewContext())
            {
                var brew = context.Brews.Find(id);
                return brew;
            }
        }

        public void EditBrew(Brew brew)
        {
            using (var context = new BrewContext())
            {
                var editingbrew = brew;
                editingbrew.UserId = userid;
                context.Entry(editingbrew).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteBrew(int id)
        {
            using (var context = new BrewContext())
            {
                var brew = context.Brews.Find(id);
                context.Brews.Remove(brew);
                context.SaveChanges();
            }
        }

        
    }
}
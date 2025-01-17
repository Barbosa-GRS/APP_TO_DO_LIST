﻿using APP_TO_DO_LIST.Context;
using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Repository.Interface;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using APP_TO_DO_LIST.Enums;
using APP_TO_DO_LIST.Model.Base;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace APP_TO_DO_LIST.Repository;

public class BaseRepository <T>: IRepository <T> where T : BaseEntity
{

    protected MySQLContext _context;  // dataset call, 

    private DbSet<T> _dataSet; 

    public BaseRepository(MySQLContext context) // constructor for injection of instance of MySQLContext ccc
    {
        _context = context;
        _dataSet = _context.Set<T>(); // pega o tipo do repositório, automatiza o processo (duvida aqui)
    }

    // responsible for find all tasks
    public List<T> FindAll()
    {
        return _dataSet.ToList();
    }

    // responsible for find expecific tasks
    public T FindById(long id)
    {
        return _dataSet.FirstOrDefault(e => e.Id.Equals(id));
    }

    // responsible for create a new task
    public T Create(T item)
    {
        try
        {
            _dataSet.Add(item);
            _context.SaveChanges();
        }
        catch (Exception)
        {

            throw;
        }
        return item;
    }

    // responsible for update task
    public T Update(T oldItem, T item) // i don't know how existingTask should be
    {
        try
        {
            _dataSet.Entry(oldItem).CurrentValues.SetValues(item); // get result and put the currente values im toDoList
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }

        return item;
    }

    // responsible for delete task
    public void Delete(T item)
    {
        try
        {
            _dataSet.Remove(item);
            _context.SaveChanges();
        }
        catch (Exception)
        {

            throw;
        }
    }
      
}

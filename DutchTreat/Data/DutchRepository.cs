﻿using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DutchTreat.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext _ctx;
        private readonly ILogger<DutchRepository> _logger;

        public DutchRepository(DutchContext ctx, ILogger<DutchRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public void AddEntity(object model)
        {
            _logger.LogInformation("AddEntity was called");
            _ctx.Add(model);
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            try
            {
                _logger.LogInformation("GetAllOrders was called");

                if (includeItems)
                {
                    return _ctx.Orders
                        .Include(o => o.Items)
                        .ThenInclude(i => i.Product)
                        .ToList();
                }
                else
                {
                    return _ctx.Orders.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Failed to get all orders: {ex}");
                return null;
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called");

                return _ctx.Products
                    .OrderBy(p => p.Title)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Failed to get all products: {ex}");
                return null;
            }
        }

        public Order GetOrderById(int id)
        {
            try
            {
                _logger.LogInformation("GetOrderById was called");

                return _ctx.Orders
                    .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                    .Where(o => o.Id == id)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Failed to get order: {ex}");
                return null;
            }
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            try
            {
                _logger.LogInformation("GetProductsByCategory was called");

                return _ctx.Products
                    .Where(p => p.Category == category)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Failed to get products by category: {ex}");
                return null;
            }
        }

        public bool SaveAll()
        {
            try
            {
                _logger.LogInformation("SaveAll was called");
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Failed to save changes: {ex}");
                return false;
            }
        }
    }
}
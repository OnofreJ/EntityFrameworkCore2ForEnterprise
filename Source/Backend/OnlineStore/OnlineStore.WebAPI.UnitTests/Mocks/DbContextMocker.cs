﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OnlineStore.Core.DataLayer;

namespace OnlineStore.WebAPI.UnitTests.Mocks
{
    public static class DbContextMocker
    {
        public static OnlineStoreDbContext GetOnlineStoreDbContextInMemory(string dbName)
        {
            // Create options for DbContext
            // Use in memory provider
            // Disable transactions because in memory database doesn't support txns
            var options = new DbContextOptionsBuilder<OnlineStoreDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .ConfigureWarnings(builder => builder.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            var dbContext = new OnlineStoreDbContext(options);

            // Seed data for DbContext instance

            dbContext
                .SeedCountries()
                .SeedCurrencies()
                .SeedCountryCurrencies()
                ;

            dbContext
                .SeedProductCategories()
                .SeedProducts()
                .SeedLocations()
                .SeedProductInventories();

            dbContext
                .SeedOrderStatuses()
                .SeedCustomers()
                .SeedEmployees()
                .SeedShippers()
                .SeedOrders()
                ;

            return dbContext;
        }
    }
}

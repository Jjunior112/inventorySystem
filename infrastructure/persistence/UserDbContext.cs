using inventorySystem.domain.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace inventorySystem.infrastructure.persistence;


public class UserDbContext(DbContextOptions options) : IdentityDbContext<User>(options);
using ImpostorHelp.Models;
using Microsoft.EntityFrameworkCore;

namespace ImpostorHelp.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Chat> Chats { get; set; }
    public DbSet<VoiceMessage> VoiceMessages { get; set; }
    
    public ApplicationContext()
    {
         Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=bot; Username=postgres; Password=sa");
    }
}
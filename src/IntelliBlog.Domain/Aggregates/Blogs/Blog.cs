﻿using System.ComponentModel;
using IntelliBlog.Domain.Aggregates.Blogs.Events;

namespace IntelliBlog.Domain.Aggregates.Blogs;
public sealed class Blog : TrackedEntity<BlogId>, IAggregateRoot
{
    public static Blog CreateNew(
        string name,
        string? description = default,
        string? smallImage = default,
        string? image = default,
        BlogStatus status = default,
        string? notes = default)
    {
        var blog = new Blog();
        blog.UpdateName(name);
        blog.UpdateDescription(description);
        blog.UpdateSmallImage(smallImage);
        blog.UpdateImage(image);
        blog.ChangeStatus(status);
        blog.UpdateNotes(notes);
        
        blog.ClearDomainEvents();
        blog.RegisterDomainEvent(new BlogCreatedEvent(blog));
        return blog;
    }

    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
    public string? Notes { get; private set; }
    // TODO: Make Image+SmallImage a ValueObject
    public string? Image { get; private set; }
    public string? SmallImage { get; private set; }
    public BlogStatus Status { get; private set; }

    public void UpdateName(string name)
    {
        if (name == this.Name) return;

        Guard.Against.NullOrWhiteSpace(name, nameof(name)); 
        
        Name = name;

        RegisterDomainEvent(new BlogUpdatedEvent(this, nameof(Name)));
    }

    public void UpdateDescription(string? description)
    {
        if (description == this.Description) return;

        Description = description;

        RegisterDomainEvent(new BlogUpdatedEvent(this, nameof(Description)));
    }                

    public void UpdateNotes(string? notes)
    {
        if (notes == this.Notes) return;

        Notes = notes;

        RegisterDomainEvent(new BlogUpdatedEvent(this, nameof(Notes)));
    }


    public void ChangeStatus(BlogStatus status)
    {
        if (status == this.Status) return;
        
        Status = status;
        
        RegisterDomainEvent(new BlogUpdatedEvent(this, nameof(Status)));
    }

    public void UpdateImage(string? image)
    {
        if (image == this.Image) return;

        Image = image;

        RegisterDomainEvent(new BlogUpdatedEvent(this, nameof(Image)));
    }

    public void UpdateSmallImage(string? smallImage)
    {
        if (smallImage == this.SmallImage) return;

        SmallImage = smallImage;

        RegisterDomainEvent(new BlogUpdatedEvent(this, nameof(SmallImage)));
    }

    private Blog() { } // For Entity Framework
}

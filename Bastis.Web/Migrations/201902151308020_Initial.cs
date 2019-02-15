namespace Bastis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agencies",
                c => new
                    {
                        AgencyID = c.Int(nullable: false, identity: true),
                        UserRegisters = c.Guid(),
                        DateRegister = c.DateTime(),
                        UserModifies = c.Guid(),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.AgencyID);
            
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        AgentID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 128),
                        Address = c.String(nullable: false, maxLength: 128),
                        EmploymentCharge = c.String(nullable: false, maxLength: 128),
                        Expirience = c.String(),
                        Email = c.String(nullable: false, maxLength: 128),
                        Phone = c.String(),
                        Mobile = c.String(nullable: false, maxLength: 128),
                        AboutMe = c.String(nullable: false, maxLength: 128),
                        SocialNetworks = c.String(nullable: false, maxLength: 128),
                        Website = c.String(),
                        ProfilePicture = c.String(),
                        AgencyID = c.Int(nullable: false),
                        UserRegisters = c.Guid(),
                        DateRegister = c.DateTime(),
                        UserModifies = c.Guid(),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.AgentID)
                .ForeignKey("dbo.Agencies", t => t.AgencyID, cascadeDelete: true)
                .Index(t => t.AgencyID);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        PropertyID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        TypeID = c.String(nullable: false),
                        StatusID = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Bedrooms = c.String(nullable: false),
                        Bathrooms = c.String(nullable: false),
                        Floors = c.String(nullable: false),
                        Garages = c.String(nullable: false),
                        Area = c.String(nullable: false),
                        Size = c.String(nullable: false),
                        SaleRentPrice = c.String(nullable: false),
                        BeforePriceLabel = c.String(nullable: false),
                        AfterPriceLabel = c.String(nullable: false),
                        VideoURL = c.String(nullable: false),
                        PropertyFeatures = c.String(nullable: false),
                        PropertyGallery = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        CountryID = c.String(nullable: false),
                        CityID = c.String(nullable: false),
                        StateID = c.String(nullable: false),
                        ZipPostalCode = c.String(nullable: false),
                        Neighborhood = c.String(nullable: false),
                        PropertyIdentification = c.Int(nullable: false),
                        DepartamentID = c.Int(nullable: false),
                        UserRegisters = c.Guid(),
                        DateRegister = c.DateTime(),
                        UserModifies = c.Guid(),
                        DateModified = c.DateTime(),
                        Agency_AgencyID = c.Int(),
                        Agent_AgentID = c.Guid(),
                        State_StateID = c.Long(),
                        Client_ClientID = c.Guid(),
                    })
                .PrimaryKey(t => t.PropertyID)
                .ForeignKey("dbo.Agencies", t => t.Agency_AgencyID)
                .ForeignKey("dbo.Agents", t => t.Agent_AgentID)
                .ForeignKey("dbo.States", t => t.State_StateID)
                .ForeignKey("dbo.Clients", t => t.Client_ClientID)
                .Index(t => t.Agency_AgencyID)
                .Index(t => t.Agent_AgentID)
                .Index(t => t.State_StateID)
                .Index(t => t.Client_ClientID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateID = c.Long(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                        UserRegisters = c.Guid(),
                        DateRegister = c.DateTime(),
                        UserModifies = c.Guid(),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.StateID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        UnifiedCode = c.String(nullable: false),
                        StateID = c.Long(nullable: false),
                        StateCode = c.String(),
                        Status = c.Boolean(nullable: false),
                        UserRegisters = c.Guid(),
                        DateRegister = c.DateTime(),
                        UserModifies = c.Guid(),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.CityID)
                .ForeignKey("dbo.States", t => t.StateID, cascadeDelete: true)
                .Index(t => t.StateID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Guid(nullable: false),
                        UserRegisters = c.Guid(),
                        DateRegister = c.DateTime(),
                        UserModifies = c.Guid(),
                        DateModified = c.DateTime(),
                        Agent_AgentID = c.Guid(),
                    })
                .PrimaryKey(t => t.ClientID)
                .ForeignKey("dbo.Agents", t => t.Agent_AgentID)
                .Index(t => t.Agent_AgentID);
            
            CreateTable(
                "dbo.CustomPermissions",
                c => new
                    {
                        CustomPermissionID = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        MenuID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomPermissionID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Menus", t => t.MenuID, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.MenuID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuID = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        ParentMenuID = c.Int(nullable: false),
                        OrderNumber = c.Int(nullable: false),
                        MenuURL = c.String(maxLength: 100),
                        MenuIcon = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.MenuID);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        PermissionID = c.Int(nullable: false, identity: true),
                        ApplicationRoleId = c.String(nullable: false, maxLength: 128),
                        MenuID = c.Int(nullable: false),
                        ViewMenu = c.Boolean(nullable: false),
                        CreateOption = c.Boolean(nullable: false),
                        ReadOption = c.Boolean(nullable: false),
                        UpdateOption = c.Boolean(nullable: false),
                        DeleteOption = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PermissionID)
                .ForeignKey("dbo.AspNetRoles", t => t.ApplicationRoleId)
                .ForeignKey("dbo.Menus", t => t.MenuID, cascadeDelete: true)
                .Index(t => t.ApplicationRoleId)
                .Index(t => t.MenuID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Leads",
                c => new
                    {
                        LeadID = c.Guid(nullable: false),
                        UserRegisters = c.Guid(),
                        DateRegister = c.DateTime(),
                        UserModifies = c.Guid(),
                        DateModified = c.DateTime(),
                        Agent_AgentID = c.Guid(),
                        Property_PropertyID = c.Int(),
                    })
                .PrimaryKey(t => t.LeadID)
                .ForeignKey("dbo.Agents", t => t.Agent_AgentID)
                .ForeignKey("dbo.Properties", t => t.Property_PropertyID)
                .Index(t => t.Agent_AgentID)
                .Index(t => t.Property_PropertyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Leads", "Property_PropertyID", "dbo.Properties");
            DropForeignKey("dbo.Leads", "Agent_AgentID", "dbo.Agents");
            DropForeignKey("dbo.Permissions", "MenuID", "dbo.Menus");
            DropForeignKey("dbo.Permissions", "ApplicationRoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CustomPermissions", "MenuID", "dbo.Menus");
            DropForeignKey("dbo.CustomPermissions", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Properties", "Client_ClientID", "dbo.Clients");
            DropForeignKey("dbo.Clients", "Agent_AgentID", "dbo.Agents");
            DropForeignKey("dbo.Properties", "State_StateID", "dbo.States");
            DropForeignKey("dbo.Cities", "StateID", "dbo.States");
            DropForeignKey("dbo.Properties", "Agent_AgentID", "dbo.Agents");
            DropForeignKey("dbo.Properties", "Agency_AgencyID", "dbo.Agencies");
            DropForeignKey("dbo.Agents", "AgencyID", "dbo.Agencies");
            DropIndex("dbo.Leads", new[] { "Property_PropertyID" });
            DropIndex("dbo.Leads", new[] { "Agent_AgentID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Permissions", new[] { "MenuID" });
            DropIndex("dbo.Permissions", new[] { "ApplicationRoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CustomPermissions", new[] { "MenuID" });
            DropIndex("dbo.CustomPermissions", new[] { "ApplicationUserId" });
            DropIndex("dbo.Clients", new[] { "Agent_AgentID" });
            DropIndex("dbo.Cities", new[] { "StateID" });
            DropIndex("dbo.Properties", new[] { "Client_ClientID" });
            DropIndex("dbo.Properties", new[] { "State_StateID" });
            DropIndex("dbo.Properties", new[] { "Agent_AgentID" });
            DropIndex("dbo.Properties", new[] { "Agency_AgencyID" });
            DropIndex("dbo.Agents", new[] { "AgencyID" });
            DropTable("dbo.Leads");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Permissions");
            DropTable("dbo.Menus");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.CustomPermissions");
            DropTable("dbo.Clients");
            DropTable("dbo.Cities");
            DropTable("dbo.States");
            DropTable("dbo.Properties");
            DropTable("dbo.Agents");
            DropTable("dbo.Agencies");
        }
    }
}

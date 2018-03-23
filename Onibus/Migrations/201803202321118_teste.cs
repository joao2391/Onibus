namespace Onibus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Motoristas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Cpf = c.String(nullable: false),
                        Cnh = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Carroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Placa = c.String(nullable: false),
                        Ano = c.Int(nullable: false),
                        Marca = c.String(nullable: false),
                        Modelo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Passageiroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Rg = c.String(nullable: false),
                        Nascimento = c.DateTime(nullable: false),
                        Viagem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Viagems", t => t.Viagem_Id)
                .Index(t => t.Viagem_Id);
            
            CreateTable(
                "dbo.rls_roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.url_roles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.rls_roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.usu_Usuario", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.usu_Usuario",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
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
                .PrimaryKey(t => t.UserId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.ucm_claims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.usu_Usuario", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.uln_logins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.usu_Usuario", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Viagems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Destino = c.String(nullable: false),
                        Data = c.DateTime(nullable: false),
                        OnibusId = c.Int(nullable: false),
                        MotoristaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Motoristas", t => t.MotoristaId, cascadeDelete: true)
                .ForeignKey("dbo.Carroes", t => t.OnibusId, cascadeDelete: true)
                .Index(t => t.OnibusId)
                .Index(t => t.MotoristaId);
            
            CreateTable(
                "dbo.usu_app_usuario",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.usu_Usuario", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.usu_app_usuario", "UserId", "dbo.usu_Usuario");
            DropForeignKey("dbo.url_roles", "IdentityUser_Id", "dbo.usu_Usuario");
            DropForeignKey("dbo.uln_logins", "IdentityUser_Id", "dbo.usu_Usuario");
            DropForeignKey("dbo.ucm_claims", "IdentityUser_Id", "dbo.usu_Usuario");
            DropForeignKey("dbo.Passageiroes", "Viagem_Id", "dbo.Viagems");
            DropForeignKey("dbo.Viagems", "OnibusId", "dbo.Carroes");
            DropForeignKey("dbo.Viagems", "MotoristaId", "dbo.Motoristas");
            DropForeignKey("dbo.url_roles", "RoleId", "dbo.rls_roles");
            DropIndex("dbo.usu_app_usuario", new[] { "UserId" });
            DropIndex("dbo.Viagems", new[] { "MotoristaId" });
            DropIndex("dbo.Viagems", new[] { "OnibusId" });
            DropIndex("dbo.uln_logins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.ucm_claims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.usu_Usuario", "UserNameIndex");
            DropIndex("dbo.url_roles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.url_roles", new[] { "RoleId" });
            DropIndex("dbo.rls_roles", "RoleNameIndex");
            DropIndex("dbo.Passageiroes", new[] { "Viagem_Id" });
            DropTable("dbo.usu_app_usuario");
            DropTable("dbo.Viagems");
            DropTable("dbo.uln_logins");
            DropTable("dbo.ucm_claims");
            DropTable("dbo.usu_Usuario");
            DropTable("dbo.url_roles");
            DropTable("dbo.rls_roles");
            DropTable("dbo.Passageiroes");
            DropTable("dbo.Carroes");
            DropTable("dbo.Motoristas");
        }
    }
}

namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_deneme : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Uruns", "Kategori_KategroiId", "dbo.Kategoris");
            DropIndex("dbo.Uruns", new[] { "Kategori_KategroiId" });
            DropColumn("dbo.Uruns", "kategoriid");
            RenameColumn(table: "dbo.Uruns", name: "Kategori_KategroiId", newName: "Kategoriid");
            DropPrimaryKey("dbo.Kategoris");
            AddColumn("dbo.Kategoris", "Kategoriid", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Uruns", "Kategoriid", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Kategoris", "Kategoriid");
            CreateIndex("dbo.Uruns", "Kategoriid");
            AddForeignKey("dbo.Uruns", "Kategoriid", "dbo.Kategoris", "Kategoriid", cascadeDelete: true);
            DropColumn("dbo.Kategoris", "KategroiId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kategoris", "KategroiId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Uruns", "Kategoriid", "dbo.Kategoris");
            DropIndex("dbo.Uruns", new[] { "Kategoriid" });
            DropPrimaryKey("dbo.Kategoris");
            AlterColumn("dbo.Uruns", "Kategoriid", c => c.Int());
            DropColumn("dbo.Kategoris", "Kategoriid");
            AddPrimaryKey("dbo.Kategoris", "KategroiId");
            RenameColumn(table: "dbo.Uruns", name: "Kategoriid", newName: "Kategori_KategroiId");
            AddColumn("dbo.Uruns", "kategoriid", c => c.Int(nullable: false));
            CreateIndex("dbo.Uruns", "Kategori_KategroiId");
            AddForeignKey("dbo.Uruns", "Kategori_KategroiId", "dbo.Kategoris", "KategroiId");
        }
    }
}

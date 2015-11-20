namespace StarTipp.DataContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BettingGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RelatedUser = c.String(),
                        Name = c.String(),
                        BettingGroup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BettingGroups", t => t.BettingGroup_Id)
                .Index(t => t.BettingGroup_Id);
            
            CreateTable(
                "dbo.GameBets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WinsGamer1 = c.Int(nullable: false),
                        WinsGamer2 = c.Int(nullable: false),
                        BettingGroup_Id = c.Int(),
                        Game_Id = c.Int(),
                        Player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BettingGroups", t => t.BettingGroup_Id)
                .ForeignKey("dbo.Games", t => t.Game_Id)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .Index(t => t.BettingGroup_Id)
                .Index(t => t.Game_Id)
                .Index(t => t.Player_Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WinsGamer1 = c.Int(nullable: false),
                        WinsGamer2 = c.Int(nullable: false),
                        PlayoffFormat = c.Int(nullable: false),
                        Gamer1_Id = c.Int(),
                        Gamer2_Id = c.Int(),
                        Stage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gamers", t => t.Gamer1_Id)
                .ForeignKey("dbo.Gamers", t => t.Gamer2_Id)
                .ForeignKey("dbo.Stages", t => t.Stage_Id)
                .Index(t => t.Gamer1_Id)
                .Index(t => t.Gamer2_Id)
                .Index(t => t.Stage_Id);
            
            CreateTable(
                "dbo.Gamers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Stage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stages", t => t.Stage_Id)
                .Index(t => t.Stage_Id);
            
            CreateTable(
                "dbo.Tournements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StageType = c.Int(nullable: false),
                        PointPolicy_Id = c.Int(),
                        Tournement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PointPolicies", t => t.PointPolicy_Id)
                .ForeignKey("dbo.Tournements", t => t.Tournement_Id)
                .Index(t => t.PointPolicy_Id)
                .Index(t => t.Tournement_Id);
            
            CreateTable(
                "dbo.PointPolicies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WinPoints = c.Int(nullable: false),
                        ScorePoints = c.Int(nullable: false),
                        RankingPositionPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TournementBettingGroups",
                c => new
                    {
                        Tournement_Id = c.Int(nullable: false),
                        BettingGroup_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tournement_Id, t.BettingGroup_Id })
                .ForeignKey("dbo.Tournements", t => t.Tournement_Id, cascadeDelete: true)
                .ForeignKey("dbo.BettingGroups", t => t.BettingGroup_Id, cascadeDelete: true)
                .Index(t => t.Tournement_Id)
                .Index(t => t.BettingGroup_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stages", "Tournement_Id", "dbo.Tournements");
            DropForeignKey("dbo.Stages", "PointPolicy_Id", "dbo.PointPolicies");
            DropForeignKey("dbo.Games", "Stage_Id", "dbo.Stages");
            DropForeignKey("dbo.Gamers", "Stage_Id", "dbo.Stages");
            DropForeignKey("dbo.TournementBettingGroups", "BettingGroup_Id", "dbo.BettingGroups");
            DropForeignKey("dbo.TournementBettingGroups", "Tournement_Id", "dbo.Tournements");
            DropForeignKey("dbo.Players", "BettingGroup_Id", "dbo.BettingGroups");
            DropForeignKey("dbo.GameBets", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.GameBets", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.Games", "Gamer2_Id", "dbo.Gamers");
            DropForeignKey("dbo.Games", "Gamer1_Id", "dbo.Gamers");
            DropForeignKey("dbo.GameBets", "BettingGroup_Id", "dbo.BettingGroups");
            DropIndex("dbo.TournementBettingGroups", new[] { "BettingGroup_Id" });
            DropIndex("dbo.TournementBettingGroups", new[] { "Tournement_Id" });
            DropIndex("dbo.Stages", new[] { "Tournement_Id" });
            DropIndex("dbo.Stages", new[] { "PointPolicy_Id" });
            DropIndex("dbo.Gamers", new[] { "Stage_Id" });
            DropIndex("dbo.Games", new[] { "Stage_Id" });
            DropIndex("dbo.Games", new[] { "Gamer2_Id" });
            DropIndex("dbo.Games", new[] { "Gamer1_Id" });
            DropIndex("dbo.GameBets", new[] { "Player_Id" });
            DropIndex("dbo.GameBets", new[] { "Game_Id" });
            DropIndex("dbo.GameBets", new[] { "BettingGroup_Id" });
            DropIndex("dbo.Players", new[] { "BettingGroup_Id" });
            DropTable("dbo.TournementBettingGroups");
            DropTable("dbo.PointPolicies");
            DropTable("dbo.Stages");
            DropTable("dbo.Tournements");
            DropTable("dbo.Gamers");
            DropTable("dbo.Games");
            DropTable("dbo.GameBets");
            DropTable("dbo.Players");
            DropTable("dbo.BettingGroups");
        }
    }
}

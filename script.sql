-- Article(Num_Art, Desig_Art, PU_Art, QttEnStock, SeuilMin, SeuilMax)
create database GestionArticles
go
use GestionArticles
go
create table Article(
Num_Art int primary key identity(1,1),
Desig_Art varchar(20),
PU_Art money,
QttEnStock int,
SeuilMin int,
SeuilMax int
)
select * from Article

insert into Article values('PC',100,10,2,30)
insert into Article values('Mouse',40,9,3,14)

--b-	 Afficher la Quantité en stocke d’un article donnée 
create procedure AfficherQttArticle(@numArt int,@Qtt int output)
as
 begin
    select @Qtt=QttEnStock from Article where Num_Art=@numArt
 end

 --c-	En donnant la quantité pour un article, calculer le montant à payer
 create procedure CalculerMontant(@numArt int,@Qtt int,@Montant decimal output)
as
begin
   select @Montant=@Qtt*PU_Art from Article where Num_Art=@numArt
end


--d-	Afficher le seuil Min et le seuil Max pour un article donné
create procedure AfficherLeSeuil(@numArt int,@sMin int output,@sMax int output)
as
begin
  select @sMin=SeuilMin,@sMax=SeuilMax from Article where Num_Art=@numArt
end

















--create article procedure
create procedure InsertArticle(@Desig varchar(20),@Pu money,@Qtt int,@sMin int,@sMax int)
as
begin
   insert into Article values(@Desig,@Pu,@Qtt,@sMin,@sMax)
end
--Edit article procedure
create procedure UpdateArticle(@numArt int,@Desig varchar(20),@Pu money,@Qtt int,@sMin int,@sMax int)
as
begin
   update Article set
   Desig_Art=@Desig ,
   PU_Art= @Pu,
   QttEnStock=@Qtt,
   SeuilMin= @sMin,
   SeuilMax= @sMax
   where Num_Art=@numArt
end

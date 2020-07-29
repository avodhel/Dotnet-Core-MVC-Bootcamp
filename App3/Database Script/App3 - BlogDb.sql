Create Database BlogDb
go

Use BlogDb
go

declare @content nvarchar(max)='Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eu ex orci. Donec non porttitor ante. Aliquam erat volutpat. Ut viverra dui sed neque iaculis facilisis. Proin pulvinar a nisi in imperdiet. Vestibulum et ipsum commodo, hendrerit tellus vitae, egestas enim. Integer risus sem, placerat sit amet lobortis in, consequat a purus. Integer vel malesuada elit. Curabitur porttitor, enim sed mollis suscipit, massa ex iaculis neque, id suscipit nisl velit sagittis erat. Sed eget risus semper, vulputate metus at, condimentum nisi. Etiam malesuada magna ac est hendrerit, a tincidunt risus bibendum. Nam arcu mi, ornare ac massa id, suscipit cursus odio. Vivamus tincidunt dictum ultricies. Quisque libero tellus, hendrerit ac consectetur sed, aliquam et nisl. Nulla porttitor cursus commodo. Nulla placerat mi non quam eleifend commodo.

Cras sit amet leo ipsum. Donec commodo ornare massa a aliquam. Phasellus et leo vestibulum, efficitur sapien viverra, tincidunt velit. Mauris eleifend, nulla eu sagittis porttitor, ipsum mi egestas tellus, eget vulputate purus erat eget mauris. Nullam hendrerit malesuada dui ac molestie. Vestibulum accumsan dui nisi, nec ullamcorper est ornare vel. Cras pellentesque, libero at gravida rhoncus, orci mi tristique ante, et pulvinar tortor dolor sed risus. In in bibendum elit, nec faucibus dolor.

Sed commodo risus vitae enim tempor, gravida tristique nisi maximus. Donec dapibus nisl consectetur lectus aliquet, ac elementum arcu porta. Ut elementum venenatis ex, vitae finibus elit auctor mollis. Quisque finibus arcu nec dolor gravida, eu aliquet turpis cursus. Vestibulum a ante in lorem eleifend maximus. Aliquam et ornare urna. In porttitor consectetur magna sit amet malesuada. Nullam risus justo, vulputate sed maximus quis, pharetra sed elit. Nullam in lorem laoreet augue venenatis malesuada. Maecenas suscipit nibh facilisis, pellentesque urna vitae, sagittis orci. Nulla fermentum nisi a leo pulvinar, at dignissim sapien mattis. Vivamus ac aliquet nisl. Nunc commodo nisl ipsum, vel bibendum lorem commodo quis. Sed eget nisl vel nunc vestibulum varius.

Praesent eu ullamcorper nibh. Nulla scelerisque molestie tempus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aenean sagittis justo convallis urna rhoncus, tincidunt scelerisque quam tempor. Aenean ac purus tempus, varius purus vulputate, euismod leo. Praesent id libero non nisi auctor condimentum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ultricies vel libero sit amet tempor. Quisque sit amet sem suscipit, placerat velit et, pulvinar mauris. Vestibulum a mi erat. In hendrerit accumsan sem. Suspendisse potenti. Morbi fringilla consequat luctus.

Nulla pharetra dolor a neque fringilla hendrerit. Etiam sit amet quam blandit, dapibus ipsum at, luctus mauris. Duis rhoncus nulla justo. Fusce semper est eget nisl malesuada, et vulputate ex fringilla. Morbi pharetra, dolor nec porta pulvinar, arcu orci vulputate nisi, consectetur ullamcorper eros mi non turpis. Nulla consequat, enim fringilla sollicitudin aliquam, nisl dui vestibulum quam, sed ultricies nibh mauris non sapien. Donec tincidunt iaculis ultrices. Duis porttitor ex id ornare fringilla. Suspendisse ut consectetur nisi, nec pellentesque risus. Quisque auctor lacus non lorem luctus, sit amet consequat lectus tristique. Aliquam fermentum nisl nunc, eu ornare lorem consectetur sed. Suspendisse potenti. Nam lacinia suscipit cursus. Etiam suscipit nisi vestibulum, maximus ante non, laoreet mauris.'

Create Table Tag
(
	Id int primary key identity,
	Name nvarchar(20) not null
)

Create Table Author
(
	Id int primary key identity,
	Name nvarchar(20) not null,
	Surname nvarchar(20) not null,
	ShortBio nvarchar(500)
)


Create Table Blog
(
	Id int primary key identity,
	Title nvarchar(250) not null,
	Content nvarchar(max) not null,
	CreateDate date not null,
	LikeCount int,
	DislikeCount int,
	AuthorId int,
	Foreign Key (AuthorId) references Author(Id)
)

Create Table BlogTag
(
	BlogId int,
	TagId int,
	Primary key(BlogId,TagId),
	Foreign Key (TagId) references Tag(Id),
	Foreign Key (BlogId) references Blog(Id)
)


Insert Into Author
Values
('Hazel','Caklı','Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut blandit sem nisl, sit amet convallis lacus malesuada sit amet. Etiam et est enim. Aenean facilisis lorem orci, imperdiet sollicitudin ligula pulvinar sed. Fusce ultrices facilisis congue. Proin bibendum interdum mauris, sed fermentum sapien bibendum et. Proin sed orci non erat molestie consequat vel ac lacus. Sed euismod nulla at sem tristique, porta pretium sapien eleifend. Nam nec diam egestas risus vulputate lobortis non sed posuere.'),
('Rick','Grimes','Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut blandit sem nisl, sit amet convallis lacus malesuada sit amet. Etiam et est enim. Aenean facilisis lorem orci, imperdiet sollicitudin ligula pulvinar sed. Fusce ultrices facilisis congue. Proin bibendum interdum mauris, sed fermentum sapien bibendum et. Proin sed orci non erat molestie consequat vel ac lacus. Sed euismod nulla at sem tristique, porta pretium sapien eleifend. Nam nec diam egestas risus vulputate lobortis non sed posuere.')

Insert Into Blog 
values
('Nasıl Hayatta Kalınır?',@content,DATEADD(month,-1,getdate()),500,10,2),
('Yazılıma Nasıl Başladım?',@content,DATEADD(month,-2,getdate()),99,100,1),
('Dünya Nasıl Değişti?',@content,DATEADD(month,-1,getdate()),500,10,2),
('İnsanlar Nasıl Dönüştü?',@content,DATEADD(day,-3,getdate()),500,10,2),
('Hala Sanat Kaldı mı?',@content,DATEADD(WEEK,-2,getdate()),500,10,2),
('Matematik ve Yazılım',@content,getdate(),500,10,2)


Insert Into Tag
values 
('Bilim'),
('Sanat'),
('Teknoloji'),
('Yaşam')

Insert Into BlogTag
values
(1,4),
(2,3),
(2,4),
(3,1),
(3,4),
(4,1),
(4,4),
(5,2),
(5,4),
(6,1),
(6,2),
(6,4)


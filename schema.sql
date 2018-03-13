DROP TABLE user_rental;
DROP TABLE movies;
DROP TABLE [user];



create table movies (
	id  int identity(1,1),
	num_of_copies INT,
	available_copies INT,
	title VARCHAR(50),
	release_date DATETIME,
	times_rented INT,
	constraint pk_movies primary key (id)
);

insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (5, 5, 'Footprints on the Moon (Le orme) (Primal Impulse)', '2017-04-22 10:37:18', 20);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (3, 3, 'The Night That Panicked America', '2017-07-02 17:43:09', 32);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (5, 5, 'Cosmonaut (Cosmonauta)', '2017-07-14 08:34:37', 12);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (3, 1, 'Last Night', '2017-07-25 10:55:29', 12);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (3, 3, 'Repast (Meshi)', '2017-05-14 02:49:19', 15);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (1, 0, 'Vixen!', '2017-04-20 13:19:49', 99);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (4, 2, 'Number One with a Bullet', '2016-11-17 20:06:35', 45);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (5, 4, 'Heaven''s Prisoners', '2016-10-30 07:32:31', 16);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (4, 4, 'Morsian yllättää', '2017-07-21 15:43:40', 11);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (4, 4, 'Auntie Mame', '2017-02-26 06:38:58', 82);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (5, 5, 'Estomago: A Gastronomic Story', '2017-07-19 16:43:32', 8);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (5, 5, 'Class', '2017-07-28 06:52:13', 28);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (2, 2, 'Fire and Ice', '2016-11-06 09:46:14', 39);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (1, 1, 'Wedding Photographer, The (Bröllopsfotografen)', '2017-09-28 08:16:48', 23);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (1, 1, 'Mexican Hayride', '2017-04-23 03:00:09', 27);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (1, 0, 'Worthless, The (Arvottomat)', '2017-02-17 03:02:49', 100);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (10, 3, 'Hours, The', '2017-09-21 04:00:21', 13);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (5, 5, 'I Accuse', '2016-10-31 04:47:00', 76);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (4, 4, 'Murmur of the Heart (Le souffle au coeur)', '2017-02-03 23:42:41', 23);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (5, 5, 'Harriet the Spy', '2017-05-09 22:17:25', 66);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (5, 5, 'Inbetweeners 2, The', '2016-12-27 06:28:17', 81);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (2, 2, 'Householder, The (Gharbar)', '2017-09-12 07:04:54', 12);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (5, 5, 'Tangled Ever After', '2017-06-30 16:10:31', 18);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (3, 3, 'Remember the Titans', '2017-04-15 05:10:15', 19);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (5, 5, 'Christmas in July', '2017-08-04 09:56:57', 2);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (2, 2, 'South, The (Sur, El)', '2016-11-21 10:54:30', 39);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (1, 1, 'Score: A Hockey Musical', '2017-04-07 19:04:10', 72);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (1, 1, 'Gift, The', '2017-06-06 23:22:22', 13);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (1, 0, 'Ainoat Oikeat', '2017-10-11 23:35:06', 19);
insert into movies (num_of_copies, available_copies, title, release_date, times_rented) values (8, 7, 'Cameron''s Closet', '2017-07-21 05:31:44', 20);





create table [user] (
	id int identity(1,1),
	email varchar(50) not null,
	[password] varchar(50) not null,
	valid_account bit,
	employee_account bit

	constraint pk_user primary key (id)
);

create table user_rental (
	rental_id int identity(1,1),
	[user_id] int not null,
	movie_id int not null,
	checkout_date datetime,
	return_date datetime 

	constraint fk_user_id foreign key ([user_id]) references [user](id),
	constraint fk_movie_id foreign key (movie_id) references movies(id),

	constraint pk_rental_id primary key (rental_id)
);


select * from [user]

select Top 5 * from movies

select * from user_rental

get.now()

UPDATE movies SET available_copies = available_copies - 1 WHERE title = 'Last Night'

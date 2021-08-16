CREATE TABLE public.book
(
    id serial PRIMARY KEY,
    title varchar
);

insert into public.book(title) values ('Advanced Calculus');
insert into public.book(title) values ('Engineering Mathematics');
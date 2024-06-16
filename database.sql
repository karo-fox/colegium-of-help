create database if not exists ColegiumOfHelpDB;
use ColegiumOfHelpDB;

create table if not exists sources(
	id int not null auto_increment,
    name char(100) not null,
    primary key(id)
);

create table if not exists races(
	id int not null auto_increment,
    name char(100) not null,
    size enum("malutki", "mały", "średni", "duży", "wielki", "ogromny"),
    speed int not null, 
    langauges char(255) not null,
    source_book int not null,
    primary key (id),
    foreign key (source_book) references sources(id)
);

create table if not exists equipment(
	id int not null auto_increment,
    name char(100) not null,
    description char(255) not null,
    rarity char(100) not null,
    weight float not null,
    cost char(20) not null,
    magic bool not null,
    alignment char(100),
    source_book int not null,
    primary key (id),
    foreign key (source_book) references sources(id)
);

create table if not exists spells(
	id int not null auto_increment,
    name char(100) not null,
    level enum("sztuczka", "1", "2", "3", "4", "5", "6", "7", "8", "9") not null,
    school enum("Iluzji", "Nekromancji", "Odpychania", "Przywoływania", "Przemiany", "Uroków", "Wieszczenia", "Wywoływania", "Inne") not null,
    casting_time char(100) not null,
    spell_range char(100) not null, 
    components char(100) not null,
    duration char(100) not null,
    concentration bool not null,
    saving_throw char(100),
    source_book int not null,
    primary key (id),
    foreign key (source_book) references sources(id)
);

create table if not exists classes(
	id int not null auto_increment, 
    name char(100) not null,
    hit_die int not null,
    proficiencies char(255) not null,
    skills_proficiencies_num int not null,
    skill_proficiencies char(255) not null,
    saving_throw_proficiencies char(255) not null,
    money int not null,
    source_book int not null,
    primary key (id),
    foreign key (source_book) references sources(id)
);

create table if not exists subclasses(
	id int not null auto_increment,
    name char(100) not null,
    class int not null,
    source_book int not null,
    primary key (id),
    foreign key (class) references classes(id),
    foreign key (source_book) references sources(id)
);
    
create table if not exists class_traits(
	id int not null auto_increment,
    name char(100) not null,
    description char(255) not null,
    refresh_time enum("short rest", "long rest", "short or long rest", "none", "other") not null,
    level int not null,
    optional bool not null,
    primary key (id)
);

create table if not exists racial_traits(
	id int not null auto_increment,
    name char(100) not null,
    description char(255) not null,
	refresh_time enum("short rest", "long rest", "short or long rest", "none", "other") not null,
    race int not null,
    primary key (id),
    foreign key (race) references races(id)
);

create table if not exists backgrounds(
	id int not null auto_increment,
    name char(100) not null,
    skill_proficiencies char(255),
    feature char(255) not null,
    source_book int not null,
    primary key (id),
    foreign key (source_book) references sources(id)
);

-- tabelki pośrednie  

create table if not exists class_equipment(
	equipment_id int not null,
    class_id  int not null,
    slot int not null,
    foreign key (equipment_id) references equipment(id),
    foreign key (class_id) references classes(id)
);    

create table if not exists background_equipment(
	equipment_id int not null,
    background_id int not null,
    foreign key (equipment_id) references equipment(id),
    foreign key (background_id) references backgrounds(id)
);

create table if not exists class_spells(
	spell_id int not null,
    class_id int not null,
    foreign key (spell_id) references spells(id),
    foreign key (class_id) references classes(id)
);

create table if not exists subclass_spells(
	spell_id int not null,
    subclass_id int not null,
    foreign key (spell_id) references spells(id),
    foreign key (subclass_id) references subclasses(id)
);

create table if not exists class_class_traits(
	class_trait_id int not null,
    class_id int not null,
    foreign key (class_trait_id) references class_traits(id),
    foreign key (class_id) references classes(id)
);

create table if not exists subclass_class_traits(
	class_trait_id int not null,
    subclass_id int not null,
    foreign key (class_trait_id) references class_traits(id),
    foreign key (subclass_id) references subclasses(id)
);

-- postacie

create table if not exists characters(
	id int not null auto_increment, 
    name char(100) not null,
    race int not null,
    background int not null,
    class int not null,
    subclass int default null,
    level int not null,
    strength int not null,
    dexterity int not null,
    constitution int not null,
    intelligence int not null,
    wisdom int not null,
    charisma int not null,
    current_HP int not null,
    total_HP int not null,
    proficiencies char(255) not null,
    langauges char(255) not null,
    equipment int not null,
    spell_slots char(255),
    primary key (id),
    foreign key (race) references races(id),
    foreign key (background) references backgrounds(id),
    foreign key (class) references classes(id),
    foreign key (subclass) references subclasses(id)
);

create table if not exists character_equipment(
	equipment_id int not null,
    character_id int not null,
    foreign key (equipment_id) references equipment(id),
    foreign key (character_id) references characters(id)
);
	
    
    
    
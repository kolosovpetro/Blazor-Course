CREATE TABLE stores (
	store_id serial PRIMARY KEY,
	store_name VARCHAR(200) NOT NULL,
	shirt_boxes INT NOT NULL,
	max_shirt_boxes INT NOT NULL,
	shoe_packs INT NOT NULL,
	max_shoe_packs INT NOT NULL,
	suit_packs INT NOT NULL,
	max_suit_packs INT NOT NULL
);
UPDATE stores
SET store_name = @storeName, 
	shirt_boxes = @shirtBoxes, 
	max_shirt_boxes = @maxShirtBoxes, 
	shoe_packs = @shoePacks, 
	max_shoe_packs = @maxShoePacks, 
	suit_packs = @suitPacks, 
	max_suit_packs = @maxSuitPacks
WHERE store_id = @storeId;
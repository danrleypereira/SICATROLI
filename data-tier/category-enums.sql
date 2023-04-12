create schema si_enums

CREATE TYPE si_enums.genre AS ENUM ('didatic', 'dictionaries', 'references', 'self-help', 'information-technology','esoterism', 'history', 'literature', 'fiction', 'science');
CREATE TYPE si_enums.pages AS ENUM ('less than 100', '100 and 300', '300 and 500', 'more than 500');
CREATE TYPE si_enums.rarity AS ENUM ('hard to find', 'easy to find', 'super easy to find', 'very fucking hard to find', 'can be brought on internet');
CREATE TYPE si_enums.price AS ENUM ('less than 50', '50 and 100', '100 and 200', '200 and 300', '300 and 500', 'more than 500');
CREATE TYPE si_enums.conservation AS ENUM ('fucked up', 'used', 'semi new', 'flawless');
  

SELECT unnest(enum_range(NULL::genre))::text AS genres_column
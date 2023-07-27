module default {

type Restaurant {
  required Name: str;
  required Email: str;
  required PhoneNumbers: array<str>;
  FacebookLink: str;
  InstagramLink: str;
  required Password: str;
  required Districts: array<str>;
  Tags: array<str>;
  OpeningHours: str;
  MenuPDF: str;
  CoverPhoto : str;
}
type RestaurantFilter {
    Name: str;
    Districts: array<str>;
    Location: str;
    Tags:array<str>;
  }
}

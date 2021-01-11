$('#client-carousel').owlCarousel({

  navigation: false, // Show next and prev buttons
  slideSpeed: 400,
  pagination: false,
  items: 3,
  rewindNav: true,
  itemsDesktop: [1199, 3],
  itemsDesktopSmall: [979, 3],
  stopOnHover: true,
  autoPlay: true

});
$('#main-slide').carousel({
  // pause: true,
  // interval: 100000
    navigation: false, // Show next and prev buttons
    slideSpeed: 400,
    pagination: false,
    items: 3,
    rewindNav: true,
    itemsDesktop: [1199, 3],
    itemsDesktopSmall: [979, 3],
    stopOnHover: true,
    autoPlay: true
});
$('a[data-rel^=\'prettyPhoto\']').prettyPhoto();

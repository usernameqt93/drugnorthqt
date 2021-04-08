$(function () {
  $.ajax({
	url: '@Url.Action("Index","Home")',
	type: 'GET',
	dataType: 'json',
	success: function (data) {
	  //Here you will get the data.
	  //Display this in your Modal popup
	  alert('Please answer to all the Question.');
	},
	error: function (data) {
	}
  });
});
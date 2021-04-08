var user = {
  init: function () {
	user.registerEvents();
  },
  registerEvents: function () {
	$('.btn-active').off('click').on('click', function (e) {
	  e.preventDefault();

	  var varBtn = $(this);
	  //var varABCId = varBtn.data('id');
	  //var varABCDId = parseFloat(varBtn.data('id'));
	  //var varId = parseInt(varBtn.data('id'));
	  var varId = varBtn.data('id');
	  $.ajax({
		url: "/TenAreaAdmin/User/JsonResultChangeStatus",
		data: { longId: varId },
		dataType: "json",
		type:"POST",
		success: function (response) {
		  console.log(response);
		  if (response.status == true) {
			varBtn.text('Kích hoạt');
		  } else {
			varBtn.text('Khóa');
		  }
		}
	  });
	});
  }
}
user.init();
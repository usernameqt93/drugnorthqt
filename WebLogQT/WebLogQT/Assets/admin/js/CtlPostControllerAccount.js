
var abc = {
  init: function () {
	abc.regEvents();
  },
  regEvents: function () {
	$('#btnCreateMetaTitle').off('click').on('click', function () {
	  var strJsTitle = document.getElementById("idTxtTitle").value;

	  $.ajax({
		url: '/AreaAccount/CtlPost/JRCreateMetaTitle',
		data: { strJsonInput: JSON.stringify(strJsTitle) },
		dataType: 'json',
		type: 'POST',
		success: function (res) {
		  if (res.blnStatusJs == true) {
			document.getElementById("idTxtMetaTitle").value = res.strOutputJs;
		  }
		}
	  })
	});

	//$('#btnCreateDescription').off('click').on('click', function () {
	//  var strJsString = document.getElementById("txtContent").value;

	//  $.ajax({
	//	url: '/AreaAccount/CtlPost/JRCreateDescription',
	//	data: { strJsonInput: JSON.stringify(strJsString) },
	//	dataType: 'json',
	//	type: 'POST',
	//	success: function (res) {
	//	  if (res.blnStatusJs == true) {
	//		document.getElementById("idTxtDescription").value = res.strOutputJs;
	//	  }
	//	}
	//  })
	//});

  }
}
abc.init();
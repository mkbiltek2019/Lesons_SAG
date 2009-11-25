// -
//
//--
var poputTimeID = setTimeout("displayPopup()", 2000); 
		
		function displayPopup() {
			var popupElement = document.getElementById("popup"); 
		
			
			popupElement.style.display = '';
			popupElement.width = 400;
			popupElement.height = 300;			
			popupElement.left = (window.clientWidth + popupElement.width) / 2;
			popupElement.top = (window.clientHeight + popupElement.height) / 2;
			
			setTimeout("showCloseButton()", 4000);
			
		}
		
		function showCloseButton() {
			var buttonElement = document.getElementById("closeButton");
			buttonElement.style.display = '';
		}
		
		function closePopup() {
			var popupElement = document.getElementById("popup");
			popupElement.style.display = 'none';
		}
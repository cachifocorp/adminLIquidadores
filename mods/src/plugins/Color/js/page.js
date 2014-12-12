$(function(){
	var hsbToHsl = function(hsb) {
		// determine the lightness in the range [0,100]
		var l = (2 - hsb.s / 100) * hsb.b / 2;
		// store the HSL components
		hsl =
		{
			h: hsb.h,
			s: hsb.s * hsb.b / (l < 50 ? l * 2 : 200 - l * 2),
			l: l
		};
		// correct a division-by-zero error
		if (isNaN(hsl.s)) hsl.s = 0;
		return hsl;
	},
	setHistoryBgs = function() {
		var cookie = $.parseJSON($.cookie('colpick_color_history'));
		if(cookie) {
			var historyDivs = $('.color-history').children('div');
			for(var i=0; i<cookie.length; i++) {
				historyDivs.eq(i).css('background-color','#'+cookie[i]).data('col',cookie[i]).addClass('color-history-en');
			}
		}
	},
	addToHistory = function(hex) {
		var cookie = $.parseJSON($.cookie('colpick_color_history'));
		if(!cookie) {
			$.cookie('colpick_color_history', JSON.stringify([hex]), {expires:365, path:'/'});
			$('.color-history').children('div').eq(0).css('background-color','#'+hex).data('col',[hex]).addClass('color-history-en');
		} else {
			if(cookie[0] != hex) {
				while(cookie.length >= 10) {
					cookie.pop();
				}
				cookie.unshift(hex);
				$.cookie('colpick_color_history', JSON.stringify(cookie), {expires:365, path:'/'});
				var historyDivs = $('.color-history').children('div');
				for(var i=0; i<cookie.length; i++) {
					historyDivs.eq(i).css('background-color','#'+cookie[i]).data('col',cookie[i]).addClass('color-history-en');
				}
			}
		}
	},
	setCurrentColor = function(col) {
		var color;
		if (typeof col == 'string') {
			color = {hsb:$.colpick.hexToHsb(col),hex:col};
		} else if (col.r != undefined && col.g != undefined && col.b != undefined) {
			color = {hex:$.colpick.rgbToHex(col),hsb:$.colpick.rgbToHsb(col)};
		} else if (col.h != undefined && col.s != undefined && col.b != undefined) {
			color = {hex:$.colpick.hsbToHex(col),hsb:col};
		} else {
			return 0;
		}
		$('.current-color-hex').text(color.hex);
	},
	getSchemeColors = function(hsbs) {
		var colors = [];
		for(var i=0; i<hsbs.length; i++) {
			var top = {h:hsbs[i].h,s:hsbs[i].s,b:Math.max(0,hsbs[i].b-25)};
			var middle = hsbs[i];
			var bottom = {h:hsbs[i].h,s:Math.max(0,hsbs[i].s-25),b:hsbs[i].b};
			colors[i] = [
				{hsb:top, hex:$.colpickHsbToHex(top)},
				{hsb:middle, hex:$.colpickHsbToHex(middle)},
				{hsb:bottom, hex:$.colpickHsbToHex(bottom)}
			];
		}
		return colors;
	},
	analogousScheme = function(hsb) {
		var compHue1 = (hsb.h+30)%360;
		var compHue2 = (hsb.h >= 30) ? hsb.h-30 : 330+hsb.h;
		var hsbs = [hsb,{h:compHue1,s:hsb.s,b:hsb.b},{h:compHue2,s:hsb.s,b:hsb.b}];
		return getSchemeColors(hsbs);
	},
	complementaryScheme = function(hsb) {
		var compHue = (hsb.h + 180)%360;
		var hsbs = [hsb,{h:compHue,s:hsb.s,b:hsb.b}];
		return getSchemeColors(hsbs);
	},
	triadScheme = function(hsb) {
		var compHue1 = (hsb.h+120)%360;
		var compHue2 = (hsb.h+240)%360;
		var hsbs = [hsb,{h:compHue1,s:hsb.s,b:hsb.b},{h:compHue2,s:hsb.s,b:hsb.b}];
		return getSchemeColors(hsbs);
	},
	squareScheme = function(hsb) {
		var compHue1 = (hsb.h+270)%360;
		var compHue2 = (hsb.h+180)%360;
		var compHue3 = (hsb.h+90)%360;
		var hsbs = [hsb,{h:compHue1,s:hsb.s,b:hsb.b},{h:compHue2,s:hsb.s,b:hsb.b},{h:compHue3,s:hsb.s,b:hsb.b}];
		return getSchemeColors(hsbs);
	},
	paintSchemeColor = function(elem,col) {
		//var textH = analogous[index][jndex].hsb.h
		var textH,textS,textB;
		textH = col.hsb.h;
		textS = col.hsb.s;
		textB = Math.min(100,col.hsb.b+25);
		if(col.hsb.b > 75) {
			textS = Math.max(0,col.hsb.s-col.hsb.b+75);
		}
		var textColor = $.colpickHsbToHex({h:textH, s:textS, b:textB});
		$(elem).css('background-color','#'+col.hex).css('color','#'+textColor).text('#'+col.hex);
	},
	fillSchemes = function(hsb) {
		var analogous = analogousScheme(hsb),
			comp = complementaryScheme(hsb),
			triad = triadScheme(hsb),
			square = squareScheme(hsb);
			
		$('#analogous-scheme>div').each(function(index){
			$(this).find('div').each(function(jndex){
				paintSchemeColor(this,analogous[index][jndex]);
			});
		});
		$('#complementary-scheme>div').each(function(index){
			$(this).find('div').each(function(jndex){
				paintSchemeColor(this,comp[index][jndex]);
			});
		});
		$('#triad-scheme>div').each(function(index){
			$(this).find('div').each(function(jndex){
				paintSchemeColor(this,triad[index][jndex]);
			});
		});
		$('#square-scheme>div').each(function(index){
			$(this).find('div').each(function(jndex){
				paintSchemeColor(this,square[index][jndex]);
			});
		});
	};
	$('#colpick').colpick({
		flat:true,
		submit:1,
		submitText:'OK',
		width:'100%',
		fontSize: '28px',
		colorScheme: 'dark',
		onChange:function(hsb, hex, rgb){
			$('#site-header').css('backgroundColor', '#' + hex);
		},
		onChangeUp:function(hsb,hex,rgb) {
			$('.current-color-hex').text(hex);
			$('#css-codes-rgb').text('rgb('+rgb.r+','+rgb.g+','+rgb.b+')');
			var hsl = hsbToHsl(hsb);
			$('#css-codes-hsl').text('hsl('+Math.round(hsl.h)+','+Math.round(hsl.s)+'%,'+Math.round(hsl.l)+'%)');
			fillSchemes(hsb);
		},
		onSubmit:function(hsb,hex,rgb) {
			addToHistory(hex);
		}
	});
	$('.color-history').children('div').click(function(ev){
		if(col = $(this).data('col')) $('#colpick').colpickSetColor(col);
		setCurrentColor(col);
	});
	
	//Brand color behaviour
	$('#home-tabs-brands li').each(function(){
		var color = $(this).find('span').text();
		$(this).css('background', color);
		
		$(this).click(function(){
			$('#colpick').colpickSetColor(color);
			setCurrentColor($.colpickHexToHsb(color));
			addToHistory(color.replace('#',''));
		});
	});
	
	//Get color from url if present
	var urlHex = decodeURIComponent((RegExp('/([a-f0-9]{6})$').exec(document.URL)||[,""])[1]);
	if(urlHex) {
		firstColor = urlHex;
		addToHistory(urlHex);
	} else {
		firstColor = 'd66920';
		setHistoryBgs();
	}
	$('#colpick').colpickSetColor(firstColor);
	setCurrentColor(firstColor);
	
	/*UI tabs*/
	$('#home-tabs').tabs();
	$('#home-tabs-list li a').tooltip({position:{my:'center bottom',at:'center top-5px'},show:false,hide:false});
	
	$('#analogous-scheme-title img').tooltip({content:'<img src="images/analogous.gif"/> Three colors that are next to each other on the color wheel. Harmonious and pleasant look.<div class="cleft"></div>',position:{my:'center top',at:'center bottom+5px'},show:false,hide:false,tooltipClass:'tooltip-scheme'});
	$('#complementary-scheme-title img').tooltip({content:'<img src="images/complementary.gif"/> Colors that are opposite on the color wheel. Vibrant look to make something stand out.<div class="cleft"></div>',position:{my:'center top',at:'center bottom+5px'},show:false,hide:false,tooltipClass:'tooltip-scheme'});
	$('#triad-scheme-title img').tooltip({content:'<img src="images/triad.gif"/> Three colors evenly spaced wround the color wheel. Vibrant look. One color should be dominating.<div class="cleft"></div>',position:{my:'center top',at:'center bottom+5px'},show:false,hide:false,tooltipClass:'tooltip-scheme'});
	$('#square-scheme-title img').tooltip({content:'<img src="images/square.gif"/> Four colors evenly spaced wround the color wheel. Let one color dominate.<div class="cleft"></div>',position:{my:'center top',at:'center bottom+5px'},show:false,hide:false,tooltipClass:'tooltip-scheme'});
});
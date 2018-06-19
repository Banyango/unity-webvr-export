/* functions called from unity */
mergeInto(LibraryManager.library, {
  FinishLoading: function() {
    document.dispatchEvent(new CustomEvent('Unity', {detail: 'Ready'}));
  },

  TestTimeReturn: function (texture) {
    document.dispatchEvent(new CustomEvent('Unity', {detail: 'Timer'}));
  },

  PostRender: function () {
    document.dispatchEvent(new CustomEvent('Unity', {detail: 'PostRender'}));
  },

  ConfigureToggleVRKeyName: function (keyName) {
    document.dispatchEvent(new CustomEvent('Unity', {detail: 'ConfigureToggleVRKeyName:' + Pointer_stringify(keyName)}));
  },

  ShowPanel: function (panelId) {
    document.dispatchEvent(new CustomEvent('Unity', {detail: {type: 'ShowPanel', panelId: Pointer_stringify(panelId)}}));
  },
  
  VRStateFromBrowser: function () {   
    var returnStr = getVRState(); 
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    return buffer; 
  }
});

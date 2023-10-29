let LoadingScreenFunction = (() => {
    var token = '';
    return {
        Show: (() => {
            $('body').loadingModal({
                position: 'auto',
                text: '',
                color: '#fff',
                opacity: '0.7',
                backgroundColor: 'rgb(0,0,0)',
                animation: 'doubleBounce'
            });
        }),
        Hide: (() => {
            $('body').loadingModal('hide');
        })
    }
})();
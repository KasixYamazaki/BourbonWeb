// OverlayScrollbars Configure
const SELECTOR_SIDEBAR_WRAPPER = '.sidebar-wrapper';
const Default = {
    scrollbarTheme: 'os-theme-light',
    scrollbarAutoHide: 'leave',
    scrollbarClickScroll: true,
};
function applySidebarState() {
    const body = document.body;
    const storedState = localStorage.getItem('sidebar-state');
    if (storedState === 'closed') {
        body.classList.remove('sidebar-open');
        body.classList.add('sidebar-collapse');
    }
}

// Apply sidebar state as early as possible
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', applySidebarState);
} else {
    applySidebarState();
}

document.addEventListener('DOMContentLoaded', function () {
    const sidebarWrapper = document.querySelector(SELECTOR_SIDEBAR_WRAPPER);
    if (sidebarWrapper && OverlayScrollbarsGlobal?.OverlayScrollbars !== undefined) {
        OverlayScrollbarsGlobal.OverlayScrollbars(sidebarWrapper, {
            scrollbars: {
                theme: Default.scrollbarTheme,
                autoHide: Default.scrollbarAutoHide,
                clickScroll: Default.scrollbarClickScroll,
            },
        });
    }

    // Save sidebar state whenever it's toggled
    const sidebarToggler = document.querySelector('[data-lte-toggle="sidebar"]');
    if (sidebarToggler) {
        sidebarToggler.addEventListener('click', () => {
            // Delay to allow AdminLTE to update classes
            setTimeout(() => {
                const isClosed = document.body.classList.contains('sidebar-collapse');
                localStorage.setItem('sidebar-state', isClosed ? 'closed' : 'open');
            }, 10);
        });
    }
});

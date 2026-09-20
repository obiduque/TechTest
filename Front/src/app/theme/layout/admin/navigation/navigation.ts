export interface NavigationItem {
  id: string;
  title: string;
  type: 'item' | 'collapse' | 'group';
  translate?: string;
  icon?: string;
  hidden?: boolean;
  url?: string;
  classes?: string;
  exactMatch?: boolean;
  external?: boolean;
  target?: boolean;
  breadcrumbs?: boolean;
  children?: NavigationItem[];
}
export const NavigationItems: NavigationItem[] = [
  {
    id: 'forms',
    title: 'Forms & Tables',
    type: 'group',
    icon: 'icon-group',
    children: [
      {
        id: 'forms-element',
        title: 'Form Elements',
        type: 'item',
        url: '/forms',
        classes: 'nav-item',
        icon: 'feather icon-file-text'
      },
      {
        id: 'tables',
        title: 'Tables',
        type: 'collapse',
        url: '/tables',
        classes: 'nav-item',
        icon: 'feather icon-server',
        children: [
          {
            id: 'usuarios',
            title: 'Usuarios',
            type: 'item',
            url: '/tables/users'
          },
          {
            id: 'tareas',
            title: 'Tareas',
            type: 'item',
            url: '/tables/tasks'
          }
        ]
      }
    ]
  }
];

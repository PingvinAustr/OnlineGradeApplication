// src/components/MainMenu.tsx
import React from 'react';
import { Layout, Menu } from 'antd';

const { Sider, Content } = Layout;

const MainMenu: React.FC = () => {
    return (
        <Layout style={{ minHeight: '100vh' }}>
            <Sider>
                <Menu theme="dark" mode="inline">
                    {/* Add menu items here */}
                    <Menu.Item key="1">Menu Item 1</Menu.Item>
                    <Menu.Item key="2">Menu Item 2</Menu.Item>
                </Menu>
            </Sider>
            <Layout>
                <Content>
                    {/* Add main content here */}
                    <div>Main content goes here</div>
                </Content>
            </Layout>
        </Layout>
    );
};

export default MainMenu;

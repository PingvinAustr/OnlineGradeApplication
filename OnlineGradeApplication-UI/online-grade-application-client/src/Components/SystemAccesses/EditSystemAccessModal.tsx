import React, { useEffect, useState } from 'react';
import { Button, Form, Input, Modal } from 'antd';
import axios from 'axios';

type SystemAccess = {
    id: number;
    firstName: string;
    lastName: string;
    role: {
        roleName: string;
    };
    systemAccess: {
        $id:number;
        username: string;
        userPassword: string;
    };
};

type EditSystemAccessModalProps = {
    record: SystemAccess | null;
    visible: boolean;
    onSave: () => void;
    onCancel: () => void;
    isEditMode: boolean;
};

const EditSystemAccessModal: React.FC<EditSystemAccessModalProps> = ({ record, visible, onSave, onCancel, isEditMode }) => {
    const [form] = Form.useForm();
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        form.setFieldsValue({
            username: record?.systemAccess.username || '',
            userPassword: record?.systemAccess.userPassword || '',
        });
    }, [record, form]);

    const onFinish = (values: any) => {
        setLoading(true);
        if (isEditMode) {
            axios.post(`https://localhost:7264/api/SystemAccess/EditSystemUser?id=${record!.systemAccess.$id}&username=${values.username}&password=${values.password}`)
                .then(onSave)
                .finally(() => setLoading(false));
        } else {
            axios.post(`https://localhost:7264/api/SystemAccess/AddSystemUser?username=${values.username}&password=${values.password}`)
                .then(onSave)
                .finally(() => setLoading(false));
        }
    };


    return (
        <Modal
            visible={visible}
            title={isEditMode ? 'Edit System Access' : 'Add System Access'}
            onCancel={onCancel}
            footer={[
                <Button key="back" onClick={onCancel}>
                    Cancel
                </Button>,
                <Button key="submit" type="primary" loading={loading} onClick={() => form.submit()}>
                    Save
                </Button>,
            ]}
        >
            <Form form={form} layout="vertical" onFinish={onFinish}>
                <Form.Item
                    name="username"
                    label="Username"
                    rules={[{ required: true, message: 'Please input the username!' }]}
                >
                    <Input />
                </Form.Item>
                <Form.Item
                    name="password"
                    label="Password"
                    rules={[{ required: true, message: 'Please input the password!' }]}
                >
                    <Input.Password />
                </Form.Item>
            </Form>
        </Modal>
    );
};

export default EditSystemAccessModal;

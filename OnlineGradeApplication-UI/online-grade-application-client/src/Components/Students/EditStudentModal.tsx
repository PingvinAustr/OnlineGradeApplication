import React, { useEffect, useState } from 'react';
import { Button, Modal, Form, Input, InputNumber } from 'antd';
import axios from 'axios';

interface EditStudentModalProps {
    visible: boolean;
    onSave: () => void;
    onUpdate:()=>void | undefined;
    onCancel: () => void;
    record: any;
    isEditMode: boolean;
}

const EditStudentModal: React.FC<EditStudentModalProps> = ({ visible, onSave,onUpdate, onCancel, record, isEditMode }) => {
    const [form] = Form.useForm();

    useEffect(() => {
        if (record) {
            form.setFieldsValue(record);
        } else {
            form.resetFields();
        }
    }, [record, form]);

    const handleSave = () => {
        form.validateFields().then(values => {
            if (isEditMode && record) {
                // Make Edit API call
                axios.post(`https://localhost:7264/api/Person/EditPerson?id=${record.id}&firstName=${values.firstName}&lastName=${values.lastName}&age=${values.age}&role=1003&systemAccess=1`);
            } else {
                // Make Add API call
                axios.post('https://localhost:7264/api/Person/AddPerson', {
                    ...values,
                    roleId: 1003,
                    systemAccessId: 1,
                });
            }

            onSave();
            onUpdate();
        });
    };

    return (
        <Modal visible={visible} onCancel={onCancel} onOk={handleSave}>
            <Form form={form}>
                <Form.Item name="firstName" rules={[{required: true, message: 'Please input the first name!'}]}>
                    <Input placeholder="First Name"/>
                </Form.Item>
                <Form.Item name="lastName" rules={[{required: true, message: 'Please input the last name!'}]}>
                    <Input placeholder="Last Name"/>
                </Form.Item>
                <Form.Item name="age" rules={[{required: true, message: 'Please input the age!'}]}>
                    <InputNumber placeholder="Age" min={1}/>
                </Form.Item>
            </Form>
        </Modal>
    );
};

export default EditStudentModal;